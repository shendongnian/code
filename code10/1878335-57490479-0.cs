    public DataSet Manage_user_profiledata(string _prof_code)
            {
                string query = string.Format(@"select * from  Function_Name(@prof_code, @first_tbl, @second_tbl)");
                NpgsqlParameter[] sqlParameters = new NpgsqlParameter[3];
                sqlParameters[0] = new NpgsqlParameter("@prof_code", NpgsqlDbType.Varchar);
                sqlParameters[0].Value = Convert.ToString(_prof_code);
              
                //
                sqlParameters[1] = new NpgsqlParameter("@first_tbl", NpgsqlTypes.NpgsqlDbType.Refcursor);
                sqlParameters[1].Value = Convert.ToString("Avilable");
                sqlParameters[1].Direction = ParameterDirection.InputOutput;
                sqlParameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Refcursor;
                //
                sqlParameters[2] = new NpgsqlParameter("@second_tbl", NpgsqlTypes.NpgsqlDbType.Refcursor);
                sqlParameters[2].Value = Convert.ToString("Assigned");
                sqlParameters[2].Direction = ParameterDirection.InputOutput;
                sqlParameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Refcursor;
                return conn.executeMultipleSelectQuery(query, sqlParameters);
    
            }
    
    
    
    
    
    public DataSet executeMultipleSelectQuery(string _query, NpgsqlParameter[] sqlParameter)
            {
                // NgpSql Init //
                npg_connection = new NpgsqlConnection(connstr);
                npg_command = new NpgsqlCommand(_query, npg_connection);
                // NgpSql Init //
                i = 0;
                try
                {
                    ds = new DataSet();
                    npg_connection.Open();
                    NpgsqlTransaction tran = npg_connection.BeginTransaction();
                    npg_command.CommandType = CommandType.Text;
                    npg_command.Parameters.AddRange(sqlParameter);
                    npg_command.ExecuteNonQuery();
                    foreach (NpgsqlParameter parm in sqlParameter)
                    {
                        if (parm.NpgsqlDbType == NpgsqlTypes.NpgsqlDbType.Refcursor)
                        {
                            if (parm.Value.ToString() != "null" || parm.Value.ToString() != "NULL" || parm.Value.ToString() != "")
                            {
                                string parm_val = string.Format("FETCH ALL IN \"{0}\"", parm.Value.ToString());
                                npg_adapter = new NpgsqlDataAdapter(parm_val.Trim().ToString(), npg_connection);
                                ds.Tables.Add(parm.Value.ToString());
                                npg_adapter.Fill(ds.Tables[i]);
                                i++;
                            }
                        }
                    }
                    tran.Commit();
                    return ds;
                }
                catch (Exception ex)
                {
                    ds_ERROR.Tables[0].Rows.Add(ex.ToString(), ex.Message.ToString());
                    return ds_ERROR;
                }
                finally
                {
                    npg_connection.Close();
                }
            }
