    IEnumerable<DataRow> res = 
        from d1 in DataTable1.AsEnumerable()
        join d2 in DataTable2.AsEnumerable() on d1["Location"] equals d2["Location"]
        select new DataRow
        {
            d1["Location"],
            d1["Visa_Q1"],
            d1["Visa_Q2"],
            d2["Visa_Q3"],
            d2["Visa_Q4"]
        };
    DataTable CombinedDataTable = res.CopyToDataTable<DataRow>();
