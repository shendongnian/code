    class WebInfo
    {
        public DataTable vrmTable{get;} 
        string myConnVRM = "Data Source = datascource;" +
                              "Initial Catalog = catalog;" +
                              "Persist Security Info=True;" +
                              "User ID=ID;" +
                              "Password=PASS;" +
                              "providerName=System.Data.SqlClient;";
        public WebInfo()
        {
            
        }
        public void GetVRMs(string vRMs, string start, string end, string acc)
        {
            SqlConnection connVRM = new SqlConnection(myConnVRM);
            vrmTable == new DataTable();
            connVRM.Open();
            SqlCommand cmdVRM = new SqlCommand("SELECT Ac, Vrm, Make, Model, MamengineSize, date FROM ReturnValue WHERE convert(varchar,[Date],101) between @StartDate and @EndDate and [AC]=@Acct", connVRM);
            cmdVRM.Parameters.AddWithValue("@acct", acc);
            cmdVRM.Parameters.AddWithValue("@from", start);
            cmdVRM.Parameters.AddWithValue("@too", end);
            SqlDataAdapter vrmAdapter = new SqlDataAdapter(cmdVRM);
            vrmAdapter.Fill(vrmTable);
            //bind to data grid and display??
        }
    }
