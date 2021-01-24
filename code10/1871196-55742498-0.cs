            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "dCurrantDate";
            dc.DataType = typeof(DateTime);
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["dCurrantDate"] =DateTime.Now;
            dt.Rows.Add(dr);`
