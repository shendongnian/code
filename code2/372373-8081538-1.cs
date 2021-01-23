                SqlDataAdapter[] dataAdapter = new SqlDataAdapter[table.Length];
                for (int i = 0; i < table.Length; i++)
                {
                    dataAdapter[i] = new SqlDataAdapter("select * from " + table[i].TableName, con);
                    SqlCommandBuilder cb = new SqlCommandBuilder(dataAdapter[i]);
                    dataAdapter[i].InsertCommand = cb.GetInsertCommand();
                    dataAdapter[i].Fill(table[i]);
                
                }
                SqlTransaction trans = con.BeginTransaction();
                try
                {
                    for(int i=0;i < table.Length;i++){
                        dataAdapter[i].InsertCommand.Transaction = trans;
                        dataAdapter[i].Update(table[i]);
                    }
                    trans.Commit();
                }
                catch(Exception ex)
                {
                    trans.Rollback();
                }
