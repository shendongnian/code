    public IEnumerable<Database1DataSet.GetProductDetailsTestRow> GetTestCases()
    {
        SqlDataAdapter da = new SqlDataAdapter("Select * From GetProductDetailsTest;", Connection);
        Database1DataSet.GetProductDetailsTestDataTable dt = new Database1DataSet.GetProductDetailsTestDataTable();
        da.Fill(dt);
        foreach (Database1DataSet.GetProductDetailsTestRow dr in dt.Rows)
        {
            yield return dr;
        }
    }
