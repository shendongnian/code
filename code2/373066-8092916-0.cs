    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using Model = ObjectLibrary.Model;
    using System.Configuration;
    using System.Collections;
    using System.Data;
    
    public class Base
    {
        protected ArrayList Parameter = new ArrayList();
        public DataTable FetchData(string spName)
        {
           //if you want to get it form app config else just hard code here
           string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
           return ConnectToSql(connectionString, spName);
        }
        protected void ClearParameter()
        {
            Parameter.Clear();
        }
        protected void AddParameter(string parameterName, object value)
        {
           Parameter.Add(new SqlParameter(parameterName,value));
        }
        private DataTable ConnectToSql(string connection, string spName)
        {
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = connection;
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(spName, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddRange(Parameter.ToArray());
                SqlDataAdapter dataAdaptor = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                dataAdaptor.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    
      }
