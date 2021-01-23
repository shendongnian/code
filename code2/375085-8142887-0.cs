    public void Run(string filename)
    {
        DataTable customers = _quickBooksAdapter.GetTableData("Customer");
        customers.WriteXml(filename);
    }
