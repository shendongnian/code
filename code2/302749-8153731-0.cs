            DataTable table = new DataTable();
            table.Columns.Add("debit", typeof (double)).DefaultValue = 0;
            table.Columns.Add("credit", typeof(double)).DefaultValue = 0;
            table.Columns.Add("net", typeof(double),"debit - credit");
            DataRow row = table.NewRow();
            
            Console.WriteLine("First: {0}",row["net"]); // won't work
            row["debit"] = 500;
            Console.WriteLine("Sec: {0}", row["net"]); // won't work
            row["credit"] = 0;
            Console.WriteLine("Thr: {0}", row["net"]); // won't work
            table.Rows.Add(row);
            Console.WriteLine(row["net"]); // works
