    public static void insertObjectMapper(string sProcName, List<T> entities)
            {
                Type type = typeof(T);
                PropertyInfo[] properties = typeof(T).GetProperties();
                string[] paramNames = null;
    
                using (SqlCommand command = new SqlCommand(sProcName, Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;    
                    SqlCommandBuilder.DeriveParameters(command);
    
                    if (command.Parameters != null || command.Parameters.Count > 0)
                    {
                        clearParameters();
                        foreach (SqlParameter parameter in command.Parameters)
                            addParameter(parameter.ParameterName, parameter.SqlDbType, parameter.Direction, parameter.Value);
                        
                        paramNames = new string[SqlParamterList.Count];
                        int count = 0;
    
                        foreach (SqlParameter parameter in SqlParamterList)
                        {                        
                            paramNames[count] = parameter.ParameterName.Substring(1);
                            ++count;
                        }
    
                        foreach (T entity in entities)
                        {
                            for (int i = 0; i <= paramNames.Length - 1; i++)
                            {
                                foreach (PropertyInfo property in properties)
                                {
                                    if (property.Name.Contains(paramNames[i]))
                                    {
                                        foreach (SqlParameter parameter in SqlParamterList)
                                        {
                                            if (parameter.ParameterName.Substring(1).Contains(paramNames[i]))
                                            {
                                                parameter.Value = entity.GetType().GetProperty(paramNames[i]).GetValue(entity, null);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            command.Parameters.Clear();
                            foreach (SqlParameter parameter in SqlParamterList)
                                command.Parameters.Add(parameter);
    
                            command.ExecuteNonQuery();
                        }
                    }        
                }
            }
