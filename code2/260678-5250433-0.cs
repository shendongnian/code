    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web;
    using System.Data.SqlClient;
    
    namespace xxx.Data    {
        public static class SqlConnectionManager
        {
            public static int ExecuteNonQuery(ConnectionConstant connectionConstant, string sql, params SqlParam[] sqlParameters)
            {
                try
                {
                    var connectionString = ConnectionStringManager.GetConnectionString(connectionConstant);
    
                    int result;
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    using (var sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = sql;
                        foreach (var parameter in sqlParameters)
                        {
                            sqlCommand.Parameters.Add(parameter.ParameterName, parameter.SqlDbType).Value = (parameter.Value).ToString() == "" ? DBNull.Value : parameter.Value;
                        }
                        sqlConnection.Open();
                        result = sqlCommand.ExecuteNonQuery();
                    }
                }
                return result;
            }
            catch (SqlException sqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable ExecuteReader(ConnectionConstant connectionConstant, string sql, params SqlParam[] sqlParameters)
        {
            try
            {
                var connectionString = ConnectionStringManager.GetConnectionString(connectionConstant);
                var result = new DataTable();
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    using (var sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = sql;
                        foreach (var parameter in sqlParameters)
                        {
                            sqlCommand.Parameters.Add(parameter.ParameterName, parameter.SqlDbType).Value = (parameter.Value).ToString() == "" ? DBNull.Value : parameter.Value;
                        }
                        sqlConnection.Open();
                        using(var dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            result.Load(dataReader);
                        }
                    }
                }
                return result;
            }
            catch (SqlException sqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static string ExecuteScalar(ConnectionConstant connectionConstant, string sql, params  SqlParam[] sqlParameters)
        {
            try
            {
                var connectionString = ConnectionStringManager.GetConnectionString(connectionConstant);
                object result = null;
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    using (var sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = sql;
                        foreach (var parameter in sqlParameters)
                        {
                            sqlCommand.Parameters.Add(parameter.ParameterName, parameter.SqlDbType).Value = (parameter.Value).ToString() == "" ? DBNull.Value : parameter.Value;
                        }
                        sqlConnection.Open();
                        result = sqlCommand.ExecuteScalar();
                    }
                }
                if (result != null)
                    return result.ToString();
                else
                    return string.Empty;
            }
            catch (SqlException sqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    }
