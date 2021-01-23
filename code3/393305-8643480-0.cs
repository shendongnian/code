    public bool IsNullOrEmptyDataTable(DataSet objDataset, int tableNo)
    {
        return objDataset == null ||
               objDataset.Table.Count <= tableNo ||
               objDataset.Tables[tableNo].Rows.Count == 0;
    }
