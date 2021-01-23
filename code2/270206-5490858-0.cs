                string sql = "Select * From Events";
                SqlCommand command = new SqlCommand(sql, conn);
                command.CommandType = CommandType.Text;
                conn.Open();
                reader = command.ExecuteReader();
                string s = string.Empty;
                while (reader.Read())
                {
                    s += "Name: " + reader["Name"].ToString() + "<br />" +
                        "Date: " + reader["Date"].ToString() + "<br />" +
                        "Location: " + reader["Location"].ToString() + "<br />";
                    
                }
                divout1.innerHtml = s;
                divout1.Visible = true;
