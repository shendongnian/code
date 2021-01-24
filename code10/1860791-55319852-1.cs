    using(Sqlconnection con = new SqlConnection(constr))
    {
         using(SqlCommand cmd = new SqlCommand("select id from Users where username = @username and password = @password", con)
         {
              cmd.Paramters.Add("@username", SqlDbType.VarChar).Value = username;
              cmd.Paramters.Add("@password", SqlDbType.VarChar).Value = password;
              con.Open();
              string result = (string)cmd.ExecuteScalar();
              if(result!=null)
              {
                  int id = int.Parse(result);
                  SecondForm frm = new SecondForm();
                  frm.UserId = id;
                  frm.Show();
              }
              else
              {
                  //tell the user that credentials are not valid
              }
         }
    }
