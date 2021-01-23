    <script language="C#" runat="server">
        private SqlConnection mySqlConnection;
        private SqlCommand mySqlCommand;
               
        Boolean ParseXml(string XMLContent){
            // Do other work
            mySqlCommand.Parameters["@CDate"].Value = DateTime.Now; 
            mySqlCommand.Parameters["@CTime"].Value = DateTime.Now; 
            mySqlCommand.Parameters["@ID"].Value = keypress; 
            mySqlCommand.Parameters["@CType"].Value = CallID; 
            // Do other work
        }
         void Page_Load(object sender, System.EventArgs e)
         {
            string connectionString = "server=abc;database=abc;uid=abc;pwd=1234"; 
            mySqlConnection = new SqlConnection(connectionString); 
            string procedureString = "Call_Import"; 
            mySqlCommand = mySqlConnection.CreateCommand(); 
            mySqlCommand.CommandText = procedureString; 
            mySqlCommand.CommandType = CommandType.StoredProcedure; 
            mySqlCommand.Parameters.Add(new SqlParameter("@CDate", SqlDbType.DateTime));
            mySqlCommand.Parameters.Add(new SqlParameter("@CTime", SqlDbType.DateTime));
            mySqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            mySqlCommand.Parameters.Add(new SqlParameter("@CType", SqlDbType.Int));
            mySqlConnection.Open(); 
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(); 
            mySqlDataAdapter.SelectCommand = mySqlCommand;
         }
         void Page_UnLoad(object sender, System.EventArgs e){
            if (mySqlConnection.State != ConnectionState.Closed)
                mySqlConnection.Close();
         }
    </script>
