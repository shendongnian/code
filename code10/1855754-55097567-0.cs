    table.AsEnumerable().GroupBy(r => r.Field<double>("Amount")).
                         Select(g => 
                         {
                             var dt = new DataTable();
                             dt.Columns.Add("Category", typeof(string));
                             dt.Columns.Add("Amount", typeof(dobule));
                             foreach (DataRow r in g)
                             {
                                 dt.ImportRow(r);
                             }
                             return dt;
                        }
