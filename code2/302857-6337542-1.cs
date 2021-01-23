    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.OracleClient;
    using System.Windows.Forms;
    using Microsoft.Win32;
    
    public class db
    {
        private string[] dataSources = { "ValidNames" };
    
        public db() {}
    
        public db(string dataSource, string userID, string password)
        {
            DataSource = dataSource;
            UserID = userID;
            Password = password;
        }
    
        private string DataSource { get; set; }
        private string UserID { get; set; }
        private string Password { get; set; }
    
        public OracleConnection GetConnection()
        {
            OracleConnection connection = null;
    
            string connectionString = 
                @"Data Source="+ DataSource + 
                ";User ID=" + UserID + 
                ";Password=" + Password + 
                ";Unicode=True";
    
            try
            {
                connection = new OracleConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
    
            return connection;
        }
    
        public List<string> GetDbList()
        {
            List<string> dataSources = new List<string>();
    
            RegistryKey reg = (Registry.LocalMachine).OpenSubKey("Software");
            reg = reg.OpenSubKey("ODBC");
            reg = reg.OpenSubKey("ODBC.INI");
            reg = reg.OpenSubKey("ODBC Data Sources");
    
            if (reg != null)
            {
                string[] items = reg.GetValueNames();
                Array.Sort(items);
                foreach (string item in items)
                    dataSources.Add(item);
            }
    
            reg.Close();
    
            return dataSources;
        }
    
        public bool IsValid()
        {
            int trueCount = 0;
    
            foreach (string dataSource in dataSources)
                if (DataSource == dataSource) trueCount++;
    
            if (trueCount > 0) return true;
            else  return false;
        }
    }
