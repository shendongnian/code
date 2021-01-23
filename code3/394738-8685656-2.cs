     SqlConnection Conn = new SqlConnection("Data Source=Localhost\\SQLEXPRESS;Initial Catalog=Flash2;Integrated Security=True;");
     SqlDataReader rdr = null;
     string commandString = "SELECT * FROM USER_MASTER";
    
     try
     {
            Conn.Open();
            SqlCommand Cmd = new SqlCommand(commandString, Conn);
            rdr = Cmd.ExecuteReader();
    
            MasterCustView.DataSource = rdr;
            MasterCustView.DataBind();
     }
     catch (Exception ex)
     {
          // Log error
     }
     finally
     {
         if (rdr != null)
         {
             rdr.Close();
         }
         if (Conn != null)
         {
             Conn.Close();
         }
      }
