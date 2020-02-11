/* Title:           New Part Number DLL
 * Date:            6-2-17
 * Author:          Terry Holmes
 * 
 * Description:     This will run the part numbers from SQL */

using NewEventLogDLL;
using System;

namespace NewPartNumbersDLL
{
    public class PartNumberClass
    {
        //setting up the class
        EventLogClass TheEventLogClass = new EventLogClass();

        MasterPartListDataSet aMasterPartListDateSet;
        MasterPartListDataSetTableAdapters.masterpartlistTableAdapter aMasterPartListTableAdapter;

        InsertPartIntoMasterPartListDataSetTableAdapters.QueriesTableAdapter aInsertPartIntoMasterPartListTableAdapter;

        FindPartFromMasterPartListByJDEPartNumberDataSet aFindPartFromMasterPartListByJDEPartNumberDataSet;
        FindPartFromMasterPartListByJDEPartNumberDataSetTableAdapters.FindPartFromMasterPartListByJDEPartNumberTableAdapter aFindPartFromMasterPartListByJDEPartNumberTableAdapter;

        FindPartFromMasterPartListByPartNumberDataSet aFindPartFromMasterPartListByPartNumberDataSet;
        FindPartFromMasterPartListByPartNumberDataSetTableAdapters.FindPartFromMasterPartListByPartNumberTableAdapter aFindPartFromMasterPartListByPartNumberTableAdapter;

        PartNumbersDataSet aPartNumbersDataSet;
        PartNumbersDataSetTableAdapters.partnumbersTableAdapter aPartNumbersTableAdapter;

        InsertPartIntoPartNumbersEntryTableAdapters.QueriesTableAdapter aInsertPartIntoPartNumbersTableAdapter;

        FindPartByPartIDDataSet aFindPartByPartIDDataSet;
        FindPartByPartIDDataSetTableAdapters.FindPartByPartIDTableAdapter aFindPartByPartIDTableAdapter;

        FindPartByJDEPartNumberDataSet aFindPartByJDEPartNumberDataSet;
        FindPartByJDEPartNumberDataSetTableAdapters.FindPartByJDEPartNumberTableAdapter aFindPartByJDEPartNumberTableAdapter;

        FindPartByPartNumberDataSet aFindPartByPartNumberDataSet;
        FindPartByPartNumberDataSetTableAdapters.FindPartByPartNumberTableAdapter aFindPartByPartNumberTableAdatper;

        FindPartByDescriptionKeyWordDataSet aFindPartByDescriptionKeyWordDataSet;
        FindPartByDescriptionKeyWordDataSetTableAdapters.FindPartByDescriptionKeyWordTableAdapter aFindPartByDescriptionKeyWordTableAdapter;

        RemovePartNumberDataSetTableAdapters.QueriesTableAdapter aRemovePartNumberTableAdapter;

        UpdatePartInformationDataSetTableAdapters.QueriesTableAdapter aUpdatePartInformationTableAdapter;

        FindMasterPartListPartByPartIDDataSet aFindMasterPartByPartIDDataSet;
        FindMasterPartListPartByPartIDDataSetTableAdapters.FindMasterPartListPartByPartIDTableAdapter aFindMasterPartByPartIDTableAdapter;

        UpdatePartNumberEntryTableAdapters.QueriesTableAdapter aUpdatePartNumberTableAdapter;

        public bool UpdatePartNumber(int intPartID, string strPartNumber)
        {
            bool blnFatalError = false;

            try
            {
                aUpdatePartNumberTableAdapter = new UpdatePartNumberEntryTableAdapters.QueriesTableAdapter();
                aUpdatePartNumberTableAdapter.UpdatePartNumber(intPartID, strPartNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class // Update Part Number " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public FindMasterPartListPartByPartIDDataSet FindMasterPartByPartID(int intPartID)
        {
            try
            {
                aFindMasterPartByPartIDDataSet = new FindMasterPartListPartByPartIDDataSet();
                aFindMasterPartByPartIDTableAdapter = new FindMasterPartListPartByPartIDDataSetTableAdapters.FindMasterPartListPartByPartIDTableAdapter();
                aFindMasterPartByPartIDTableAdapter.Fill(aFindMasterPartByPartIDDataSet.FindMasterPartListPartByPartID, intPartID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Numbers DLl // Find Master Part By Part ID " + Ex.Message);
            }

            return aFindMasterPartByPartIDDataSet;
        }
        public bool UpdatePartInformation(int intPartID, string strJDEPartNumber, string strDescription, bool blnActive, float fltPrice)
        {
            bool blnFatalError = false;

            try
            {
                aUpdatePartInformationTableAdapter = new UpdatePartInformationDataSetTableAdapters.QueriesTableAdapter();
                aUpdatePartInformationTableAdapter.UpdatePartInformation(intPartID, strJDEPartNumber, strDescription, blnActive, fltPrice);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Update Part Information " + Ex.Message);
            }

            return blnFatalError;
        }
        public bool RemovePartNumber(int intPartID)
        {
            bool blnFatalError = false;

            try
            {
                aRemovePartNumberTableAdapter = new RemovePartNumberDataSetTableAdapters.QueriesTableAdapter();
                aRemovePartNumberTableAdapter.RemovePartNumber(intPartID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Remove Part Number " + Ex.Message);
            }

            return blnFatalError;
        }
        public FindPartByDescriptionKeyWordDataSet FindPartByDescriptionKeyWord(string strDescription)
        {
            try
            {
                aFindPartByDescriptionKeyWordDataSet = new FindPartByDescriptionKeyWordDataSet();
                aFindPartByDescriptionKeyWordTableAdapter = new FindPartByDescriptionKeyWordDataSetTableAdapters.FindPartByDescriptionKeyWordTableAdapter();
                aFindPartByDescriptionKeyWordTableAdapter.Fill(aFindPartByDescriptionKeyWordDataSet.FindPartByDescriptionKeyWord, strDescription);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Find Part By Description Key Word " + Ex.Message);
            }

            return aFindPartByDescriptionKeyWordDataSet;
        }
        public FindPartByPartNumberDataSet FindPartByPartNumber(string strPartNumber)
        {
            try
            {
                aFindPartByPartNumberDataSet = new FindPartByPartNumberDataSet();
                aFindPartByPartNumberTableAdatper = new FindPartByPartNumberDataSetTableAdapters.FindPartByPartNumberTableAdapter();
                aFindPartByPartNumberTableAdatper.Fill(aFindPartByPartNumberDataSet.FindPartByPartNumber, strPartNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Find Part By Part Number " + Ex.Message);
            }

            return aFindPartByPartNumberDataSet;
        }
        public FindPartByJDEPartNumberDataSet FindPartByJDEPartNumber(string strJDEPartNumber)
        {
            try
            {
                aFindPartByJDEPartNumberDataSet = new FindPartByJDEPartNumberDataSet();
                aFindPartByJDEPartNumberTableAdapter = new FindPartByJDEPartNumberDataSetTableAdapters.FindPartByJDEPartNumberTableAdapter();
                aFindPartByJDEPartNumberTableAdapter.Fill(aFindPartByJDEPartNumberDataSet.FindPartByJDEPartNumber, strJDEPartNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Find Part By JDE Part Number " + Ex.Message);
            }

            return aFindPartByJDEPartNumberDataSet;
        }
        public FindPartByPartIDDataSet FindPartByPartID(int intPartID)
        {
            try
            {
                aFindPartByPartIDDataSet = new FindPartByPartIDDataSet();
                aFindPartByPartIDTableAdapter = new FindPartByPartIDDataSetTableAdapters.FindPartByPartIDTableAdapter();
                aFindPartByPartIDTableAdapter.Fill(aFindPartByPartIDDataSet.FindPartByPartID, intPartID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Find Part By Part ID " + Ex.Message);
            }

            return aFindPartByPartIDDataSet;
        }

        public bool InsertPartIntoPartNumbers(int intPartID, string strPartNumber, string strJDEPartNumber, string strDescription, float fltPrice)
        {
            bool blnFatalError = false;

            try
            {
                aInsertPartIntoPartNumbersTableAdapter = new InsertPartIntoPartNumbersEntryTableAdapters.QueriesTableAdapter();
                aInsertPartIntoPartNumbersTableAdapter.InsertPartIntoPartNumbers(intPartID, strPartNumber, strJDEPartNumber, strDescription, true, fltPrice);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Insert Part Into Part Numbers " + Ex.Message);
            }

            return blnFatalError;
        }
        public PartNumbersDataSet GetPartNumbersInfo()
        {
            try
            {
                aPartNumbersDataSet = new PartNumbersDataSet();
                aPartNumbersTableAdapter = new PartNumbersDataSetTableAdapters.partnumbersTableAdapter();
                aPartNumbersTableAdapter.Fill(aPartNumbersDataSet.partnumbers);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Get Part Numbers Info " + Ex.Message);
            }

            return aPartNumbersDataSet;
        }
        public void UpdatePartNumbersDB(PartNumbersDataSet aPartNumbersDataSet)
        {
            try
            {
                aPartNumbersTableAdapter = new PartNumbersDataSetTableAdapters.partnumbersTableAdapter();
                aPartNumbersTableAdapter.Update(aPartNumbersDataSet.partnumbers);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Update Part Numbers DB " + Ex.Message);
            }
        }
        public FindPartFromMasterPartListByPartNumberDataSet FindPartFromMasterPartListByPartNumber(string strPartNumber)
        {
            try
            {
                aFindPartFromMasterPartListByPartNumberDataSet = new FindPartFromMasterPartListByPartNumberDataSet();
                aFindPartFromMasterPartListByPartNumberTableAdapter = new FindPartFromMasterPartListByPartNumberDataSetTableAdapters.FindPartFromMasterPartListByPartNumberTableAdapter();
                aFindPartFromMasterPartListByPartNumberTableAdapter.Fill(aFindPartFromMasterPartListByPartNumberDataSet.FindPartFromMasterPartListByPartNumber, strPartNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Find Part from Master Part List By JDE Part Number " + Ex.Message);
            }

            return aFindPartFromMasterPartListByPartNumberDataSet;
        }
        public FindPartFromMasterPartListByJDEPartNumberDataSet FindPartFromMasterPartListByJDEPartNumber(string strJDEPartNumber)
        {
            try
            {
                aFindPartFromMasterPartListByJDEPartNumberDataSet = new FindPartFromMasterPartListByJDEPartNumberDataSet();
                aFindPartFromMasterPartListByJDEPartNumberTableAdapter = new FindPartFromMasterPartListByJDEPartNumberDataSetTableAdapters.FindPartFromMasterPartListByJDEPartNumberTableAdapter();
                aFindPartFromMasterPartListByJDEPartNumberTableAdapter.Fill(aFindPartFromMasterPartListByJDEPartNumberDataSet.FindPartFromMasterPartListByJDEPartNumber, strJDEPartNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Find Part from Master Part List By JDE Part Number " + Ex.Message);
            }

            return aFindPartFromMasterPartListByJDEPartNumberDataSet;
        }
        public bool InsertPartIntoMasterPartList(int intPartID, string strPartNumber, string strJDEPartNumber, string strDescription, float fltPrice)
        {
            bool blnFatalError = false;

            try
            {
                aInsertPartIntoMasterPartListTableAdapter = new InsertPartIntoMasterPartListDataSetTableAdapters.QueriesTableAdapter();
                aInsertPartIntoMasterPartListTableAdapter.InsertPartIntoMasterPartList(intPartID, strPartNumber, strJDEPartNumber, strDescription, true, fltPrice);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Insert Part Into Master Part List " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public MasterPartListDataSet GetMasterPartListInfo()
        {
            try
            {
                aMasterPartListDateSet = new MasterPartListDataSet();
                aMasterPartListTableAdapter = new MasterPartListDataSetTableAdapters.masterpartlistTableAdapter();
                aMasterPartListTableAdapter.Fill(aMasterPartListDateSet.masterpartlist);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Get Master Part List Info " + Ex.Message);
            }

            return aMasterPartListDateSet;
        }
        public void UpdateMasterPartListDB(MasterPartListDataSet aMasterPartListDateSet)
        {
            try
            {
                aMasterPartListTableAdapter = new MasterPartListDataSetTableAdapters.masterpartlistTableAdapter();
                aMasterPartListTableAdapter.Update(aMasterPartListDateSet.masterpartlist);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "New Part Number DLL // Update Master Part List DB " + Ex.Message);
            }
        }
    }
}
