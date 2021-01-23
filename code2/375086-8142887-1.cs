    public void Run(Stream output)
    {
        DataTable customers = _quickBooksAdapter.GetTableData("Customer");
        customers.WriteXml(output);
    }
