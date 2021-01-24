                SqlConnection sqlcon = new SqlConnection(@"");
                string query = "select * from dbo.users where name= '" + name.Text+ "' and password = '" + dbo.users where pword= '" + pword.Text+ "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                   string userRights = dtbl.Rows[0]["userrights"].ToType<string>();
                   switch (userRights)
                   {
                      case "admin":
                         *do something*
                      break;
                      case "user":
                         *do something else*
                      break;
                   }
                }
