                yourDataTable.Columns.Add("newCol", typeof(double));
                foreach (System.Data.DataRow row in yourDataTable.Rows)
                {
                    row["newCol"] = Math.Round(Convert.ToDouble(row["oldCol"]), 2);                    
                }
