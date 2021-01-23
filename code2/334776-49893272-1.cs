    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    using System.Data.Common;
    using MySql.Data.MySqlClient;
    using MySql.Data;
    using Oracle.DataAccess;
    using Oracle.DataAccess.Client;
    
     public class DBManagement  
        {
            string connectionStr;
            DbConnection con;
            DbCommand cmd;
            DbDataAdapter AD;
            DataSet ds;
            DbParameter[] sp;
            IDBManagement Iobj = null;
            public DBManagement()
            {
                this.Initialize();
            }
    
     void Initialize()
            {
                try
                {
    
                    switch (ConfigurationManager.AppSettings["ActiveDatabase"].ToUpper())
                    {
                        case "MSSQL":
                            connectionStr = ConfigurationManager.ConnectionStrings["MSSQLConnectionString"].ConnectionString;
                            con = new SqlConnection();
                            cmd = new SqlCommand();
                            AD = new SqlDataAdapter();
                            break;
                        case "ORACLE":
                            connectionStr = ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;
                            con = new OracleConnection();
                            cmd = new OracleCommand();
                            AD = new OracleDataAdapter();
                            break;
                        case "MYSQL":
                            connectionStr = ConfigurationManager.ConnectionStrings["MYSQLConnectionString"].ConnectionString;
                            con = new MySqlConnection();
                            cmd = new MySqlCommand();
                            AD = new MySqlDataAdapter();
                            break;
                        default:
    
                            break;
                    }
    
                    con.ConnectionString = connectionStr;
                    cmd.Connection = con;
                }
                catch (Exception ex)
                {
    
                }
            }
    
            public DataSet ExecuteProcedure(string procName, CommandType cmdType, Parameter[] DBParameters = null)
            {
                try
                {
                    cmd.CommandText = procName;
                    cmd.CommandType = cmdType;
    
                    cmd.Parameters.Clear();
    
                    if (DBParameters != null && DBParameters.Length > 0)
                    { 
                        sp = DBParameters.ToParamerArray(cmd);  
                        cmd.Parameters.AddRange(sp); 
                    }
                    ds = new DataSet();
                    AD.SelectCommand = cmd;
                    AD.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    }
