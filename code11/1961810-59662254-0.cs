    DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Id", typeof(System.Int32)));
                DataRow dr2 = dt.NewRow();
                dr2["Profit"] = DBNull.Value;
                dt.Rows.Add(dr2);
                var sum=dt.Compute("Sum(Profit)", "Profit>=0");
                if (DBNull.Value.Equals(sum))
                    Console.WriteLine("the value is null");
                if(string.IsNullOrWhiteSpace(sum.ToString()))
                    Console.WriteLine("the sum is null");
