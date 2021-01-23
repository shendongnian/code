    DataTable salesTable = new DataTable();
    salesTable.Columns.Add("InvoiceNum", typeof(string));
    salesTable.Columns.Add("Amount", typeof(decimal));
    salesTable.Columns.Add("LineNum", typeof(int));
    salesTable.Columns.Add("LineAmount", typeof(decimal));
    salesTable.Columns.Add("Ledger", typeof(string));
    // this is just to populate data for the sample, omit as you already have your data
    salesTable.Rows.Add("INV1", 100M, 1, 50M, "11101");
    salesTable.Rows.Add("INV1", 100M, 1, 50M, "25631");
