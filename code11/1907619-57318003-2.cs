    using System.Data.Sql;
    using System.Data;
    using System.Configuration;
    using System.Windows;
    using System.Data.SqlClient;
    using System;
    using System.Windows.Forms;
      namespace OJT.DAL
{
    public class OJT_Data
    {
        public SqlConnection sQLConnection = new SqlConnection();
        public SqlCommand aCommand = new SqlCommand();
        private string DatabaseName = "";
        public string strConnStr;
        private string strDatabaseName = "";
        public void openDB()
        {
            sQLConnection.ConnectionString = strConnStr;
            sQLConnection.Close();
            sQLConnection.Open();
            aCommand = sQLConnection.CreateCommand();
        }
        public SqlDataReader ReturnData(string SQLDBCommand)
        {
            SqlDataReader r = null;
            try
            {
                aCommand.CommandText = SQLDBCommand;
                r =   aCommand.ExecuteReader(System.Data.CommandBehavior.Default);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return r;
        }
        public bool CheckTableExists(string strTableName)
        {
            bool tableExists = false;
            DataTable dt = sQLConnection.GetSchema("tables");
            foreach (DataRow row in dt.Rows)
            {
                string strTbleName = row["TABLE_NAME"].ToString();
                if (row["TABLE_NAME"].ToString() == strTableName)
                {
                    tableExists = true;
                    break;
                }
            }
            return tableExists;
        }
        public DataSet ReturnDataSet(string SQLSelectCommand)
        {
            SqlDataAdapter daGeneric = new SqlDataAdapter(SQLSelectCommand, this.sQLConnection);
            DataSet ds = new DataSet();
            daGeneric.Fill(ds);
            return ds;
        }
        public bool UpdateData(string OdbcCommand)
        {
            bool ret = false;
            try
            {
                aCommand.CommandType = CommandType.Text;
                aCommand.CommandText = OdbcCommand;
                int i = aCommand.ExecuteNonQuery();
                if (i > 0)
                    ret = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                ret = false;
            }
            finally
            {
                //               conn.Close();
            }
            return ret;
        }
    }
