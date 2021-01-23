        DataTable dt = GetTable(); // Assume this method returns the datatable from service      
        DataTable dt2 = dt.Clone();
        dt2.Columns["Code"].DataType = Type.GetType("System.Int32");
        foreach (DataRow dr in dt.Rows)
        {
            dt2.ImportRow(dr);
        }
        dt2.AcceptChanges();
        DataView dv = dt2.DefaultView;
        dv.Sort = "Code ASC";
