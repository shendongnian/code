        DataTable dt = new System.Data.DataTable();
        
        dt.Columns.Add("SampleID", typeof(Int32));
        dt.Columns.Add("SampleKey", typeof(Int32));
        dt.Columns.Add("SampleData", typeof(string));
        
        dt.Rows.Add(1, 1, "abc");
        dt.Rows.Add(1, 2, "def");
        dt.Rows.Add(2, 1, "xxx");
        dt.Rows.Add(2, 3, "yyy");
        dt.Rows.Add(3, 3, "zzz");
        dt.Rows.Add(3, 4, "qqq");
        var result = from DataRow myRow in dt.Rows  
                     where (int)myRow["SampleID"] == 3 || (int)myRow["SampleKey"] == 3
                     select myRow;
