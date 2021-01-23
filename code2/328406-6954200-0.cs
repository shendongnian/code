            string sql = "select top 10 * from [TestTable]";
            string connStr = ConfigurationManager.ConnectionStrings["DbConnString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                da.Fill(data);
                foreach (DataColumn col in data.Columns)
                {
                    Console.WriteLine(
                        string.Format("{0}\t{1}\t{2}",
                                col.ColumnName,
                                col.DataType.ToString(),
                                col.MaxLength
                            )
                        );
                }
                Console.ReadLine();
            }
