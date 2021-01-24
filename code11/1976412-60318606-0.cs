    [DataTestMethod]
    [DataRow(13)]
    [DataRow(18)]
    //...
    [DataRow(nn)]
    public void GetTestValuesFromTestParameter(int workItemId) {
        //Code to get the data from TFS
        DataTable data = GetTableItemsFromTestCase(workItemId);
        //...
    }
    private DataTable GetTableItemsFromTestCase(int workItemId) {
        //Return the data table items from TFS
    }
