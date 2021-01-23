        public static bool CreateEntity(object entity, out long id)
        {
            bool created = false;
            long newid = -1;
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(Provider.Connection()))
            {
                string sqlcreate = "select * from {0} where id = -1;";
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(String.Format(sqlcreate, entity.GetType().UnderlyingSystemType.Name), conn))
                {
                    using (SqlCommandBuilder build = new SqlCommandBuilder(da))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            DataRow dr = ds.Tables[0].NewRow();
                            ClassProperties.Update(entity, dr);
                            da.InsertCommand = build.GetInsertCommand();
                            da.InsertCommand.CommandText += ";SELECT SCOPE_IDENTITY()";
                            da.InsertCommand.Parameters.Clear();
                            for (int i = 1; i < dr.ItemArray.Length; i++)
                            {
                                da.InsertCommand.Parameters.AddWithValue("@p" + i, dr.ItemArray[i]);
                            }
                            var result = da.InsertCommand.ExecuteScalar();
                            if (result != null)
                            {
                                created = true;
                                newid = Convert.ToInt64(result);
                            }
                        }
                    }
                }
            }
            id = newid;
            return created;
        }
