     string alterSQL;
     alterSQL = "ALTER TABLE Products3 ";
     alterSQL += "ADD @txtIP_TextField bool()";
     SqlConnection con = new SqlConnection(GetConnectionString());
     SqlCommand cmd = new SqlCommand(alterSQL, con);
     cmd.Parameters.AddWithValue("@txtIP_TextField ", txtIP_TextField.Text);
