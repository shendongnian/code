    public void BulkLoadWithArrayBinding(System.Data.DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            List<OracleParameter> parameters = new List<OracleParameter>(dt.Columns.Count);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            sb.Append("INSERT INTO \"" + dt.TableName + "\" (");
            foreach (DataColumn dc in dt.Columns)
            {
                sb.Append("\"" + dc.ColumnName.ToUpper() + "\"");
                if (dc.Ordinal < dt.Columns.Count - 1)
                    sb.AppendLine(",");
            }
            sb.Append(") VALUES(");
            foreach (DataColumn dc in dt.Columns)
            {
                string parameterName = dc.ColumnName.ToUpper();
                sb.Append(":" + parameterName);
                if (dc.Ordinal < dt.Columns.Count - 1)
                    sb.AppendLine(",");
                OracleString[] sArray = null;
                OracleDate[] dArray = null;
                OracleDecimal[] dbArray = null;
                OracleParameter p = null;
                if (dc.DataType.Name == "String")
                {
                    sArray = new OracleString[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][dc.Ordinal] != DBNull.Value)
                            sArray[i] = dt.Rows[i][dc.Ordinal].ToString();
                        else
                            sArray[i] = OracleString.Null;
                    }
                    p = new OracleParameter(parameterName,OracleDbType.Varchar2, dt.Rows.Count, ParameterDirection.Input);
                    p.Size = sArray.Length;
                    p.Value = sArray;
                }
                else if (dc.DataType.Name == "DateTime")
                {
                    dArray = new OracleDate[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][dc.Ordinal] != DBNull.Value)
                            try
                            {
                                dArray[i] = (OracleDate)Convert.ToDateTime(dt.Rows[i][dc.Ordinal]);
                            }
                            catch
                            {
                                object o = dt.Rows[i][dc.Ordinal];
                                dArray[i] = OracleDate.Null;
                            }
                        else
                        {
                            dArray[i] = OracleDate.Null;
                        }
                    }
                    p = new OracleParameter(parameterName,OracleDbType.Date, dt.Rows.Count, ParameterDirection.Input);
                    p.Size = dArray.Length;
                    p.Value = dArray;
                }
                else if (dc.DataType.Name == "Double")
                {
                    dbArray = new OracleDecimal[dt.Rows.Count]; ;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][dc.Ordinal] != DBNull.Value)
                            dbArray[i] = Convert.ToDecimal(dt.Rows[i][dc.Ordinal]);
                        else
                            dbArray[i] = OracleDecimal.Null;
                    }
                    p = new OracleParameter(parameterName, OracleDbType.Decimal, dt.Rows.Count, ParameterDirection.Input);
                    p.Value = dbArray;
                }
                else if (dc.DataType.Name == "Boolean")
                {
                    dbArray = new OracleDecimal[dt.Rows.Count]; ;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][dc.Ordinal] != DBNull.Value)
                            dbArray[i] = Convert.ToDecimal(dt.Rows[i][dc.Ordinal]);
                        else
                            dbArray[i] = OracleDecimal.Null;
                    }
                    p = new OracleParameter(parameterName, OracleDbType.Decimal, dt.Rows.Count, ParameterDirection.Input);
                    p.Value = dbArray;
                }
                cmd.Parameters.Add(p);
            }
            sb.AppendLine(")");
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.ArrayBindCount = dt.Rows.Count;
            cmd.BindByName = true;
            cmd.AddToStatementCache = true;
            cmd.ExecuteNonQuery();
            foreach (OracleParameter p in cmd.Parameters)
            {                
                p.Dispose();
            }
            cmd.Dispose();                       
        }
