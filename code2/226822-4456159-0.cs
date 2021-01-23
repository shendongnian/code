        using (SqlConnection con = new SqlConnection(conString))
        {
            conn.Open(); //this was missing
            using (SqlCommand cmd = new SqlCommand("administratorUpdate", con))
            {
                cmd.Parameters.Add("@originalID", SqlDbType.VarChar).Value = IDHF.Value;
                cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstNameTB.Text;
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastNameTB.Text;
                cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = userNameTB.Text;
                cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar).Value = emailAddressTB.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNontQuery(); //this was missing.
            }
            conn.Close();
        }
