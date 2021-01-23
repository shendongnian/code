    //Existing code
    rdr = Cmd.ExecuteReader();
    MasterCust.DataSource = myReader;    
    MasterCust.DataBind();
    
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
