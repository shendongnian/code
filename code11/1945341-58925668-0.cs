     using (SqlConnection conn = new SqlConnection(connString))
     {
          if (ddlCoffee.SelectedIndex != 0)
          {
               conn.Open();
               using (SqlCommand sqlcmd = new SqlCommand(insertCommand, conn))
               {
                    sqlcmd.Parameters.AddWithValue("@DrinkName", lblCoffee.Text);
                    sqlcmd.Parameters.AddWithValue("@DateOfOrder", DateTime.Today);
    
                    sqlcmd.Parameters.AddWithValue("@Qty", ddlCoffee.SelectedValue);
             
                    sqlcmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                    sqlcmd.Parameters.AddWithValue("@UserCompany", txtCompanyName.Text);
                    sqlcmd.ExecuteNonQuery();
               }
          }
     }
