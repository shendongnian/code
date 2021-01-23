    // I am building this table in code just for the purposes of this answer.
    // If you already have your data table, ignore!
    DataTable salesTable = new DataTable();
    salesTable.Columns.Add("InvoiceNum", typeof(string));
    salesTable.Columns.Add("Amount", typeof(decimal));
    salesTable.Columns.Add("LineNum", typeof(int));
    salesTable.Columns.Add("LineAmount", typeof(decimal));
    salesTable.Columns.Add("Ledger", typeof(string));
    // This is also just to populate data for the sample.
    // Omit as you already have your data.
    salesTable.Rows.Add("INV1", 100M, 1, 50M, "11101");
    salesTable.Rows.Add("INV1", 100M, 1, 50M, "25631");
