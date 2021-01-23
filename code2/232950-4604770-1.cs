            DataSet ds = new DataSet();
            DataTable dtt = new DataTable();
            ds.Tables.Add(dtt);
            // simulate required columns
            dtt.Columns.Add("col1", typeof(int));
            dtt.Columns.Add("col2", typeof(string));
            //...
            dtt.Columns.Add("col18", typeof(DateTime));
            // pupulate with dummy date
            for (int index = 0; index < 100; index++)
            {
                dtt.Rows.Add(index, "val" + index.ToString(), DateTime.Now.AddMinutes(index));
            }
            // add new column
            DataColumn colEndDate = new DataColumn("EndDate", typeof(DateTime));
            dtt.Columns.Add(colEndDate);
            // get old column reference
            DataColumn colOld18 = dtt.Columns["col18"];
            // loop thru all rows
            foreach (DataRow row in dtt.Rows)
            {
                // store value from old column to new column
                row[colEndDate] = Convert.ToDateTime(row[colOld18]).ToShortDateString();
                // or
                row[colEndDate] = Convert.ToDateTime(row[colOld18]).ToString("MM/dd/yyyy hh:mm:ss");
            }
            // remove old column
            dtt.Columns.Remove(colOld18);
            dtt.AcceptChanges();
