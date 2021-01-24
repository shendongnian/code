     List<string> A = new List<string>() { "a", "b", "c" };
                DataTable dt = new DataTable();
                dt.Columns.Add("a");
                dt.Columns.Add("b");
                dt.Columns.Add("c");
                dt.Columns.Add("d");
                dt.Columns.Add("e");
                foreach (string col in A)
                {
                    dt.Columns.Remove(col);
                }
                foreach (DataColumn column in dt.Columns)
                {
                    WriteLine(column.ColumnName);
                    WriteLine(" ");
                }
