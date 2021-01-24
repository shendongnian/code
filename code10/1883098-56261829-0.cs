      SqlCommand command = conn.CreateCommand();
        command.CommandText = "select Test from PrescTest ";
        
        conn.Open();
        
        //Nothing to execute so you can scrap this line
        //command.ExecuteNonQuery();
        
        SqlDataReader dr2 = command.ExecuteReader();
        try {
    string Tests = "";
    
         if (dr2.HasRows) {
         
          while (dr2.Read()) {
           // get the results of column "Test"
           Tests += dr2["Test"].ToString() + " ";
          }
        
         }
          TextBox15.Text = Tests.Trim();
          conn.Close();
        } catch (SqlException sqlexception) {
         Response.Write("ERROR ::" + sqlexception.Message);
        } catch (Exception ex) {
         Response.Write("ERROR ::" + ex.Message);
        } finally {
         conn.Close();
        }
