            using (SqlConnection con = new SqlConnection(connstring))
            {
                
                con.Open();
    
                SqlCommand cmd = new SqlCommand("usb_update_empdtls", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar, -1).Value = TextBox1.Text.ToString();
                SqlParameter parEmployeeID = AddInputParameters("@EmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, TextBox1.Text);
              
                SqlParameter parLastName = AddInputParameters("@LastName", SqlDbType.VarChar, 20, ParameterDirection.Input, TextBox2.Text);
                SqlParameter parFirstName = AddInputParameters("@FirstName", SqlDbType.VarChar, 20, ParameterDirection.Input, TextBox3.Text);
                SqlParameter parTitle = AddInputParameters("@Title", SqlDbType.VarChar, 100, ParameterDirection.Input, TextBox4.Text);
                SqlParameter parPresentAddress = AddInputParameters("@PresentAddress", SqlDbType.VarChar, 60, ParameterDirection.Input, TextBox5.Text);
                SqlParameter parCity = AddInputParameters("@City", SqlDbType.VarChar, 50, ParameterDirection.Input, TextBox6.Text);
                SqlParameter parPostalCode = AddInputParameters("@PostalCode", SqlDbType.VarChar, 10, ParameterDirection.Input, TextBox7.Text);
                SqlParameter parCountry = AddInputParameters("@Country", SqlDbType.VarChar, 50, ParameterDirection.Input, TextBox8.Text);
                SqlParameter parExtension = AddInputParameters("@Extension", SqlDbType.VarChar, 4, ParameterDirection.Input, TextBox9.Text);
                SqlParameter parResult = AddOutputParameter("@Result", SqlDbType.VarChar, 100, ParameterDirection.Output);
                cmd.Parameters.Add(parEmployeeID);
                cmd.Parameters.Add(parLastName);
                cmd.Parameters.Add(parFirstName);
                cmd.Parameters.Add(parTitle);
                cmd.Parameters.Add(parPresentAddress);
                cmd.Parameters.Add(parCity);
                cmd.Parameters.Add(parPostalCode);
                cmd.Parameters.Add(parCountry);
                cmd.Parameters.Add(parExtension);
                cmd.Parameters.Add(parResult);
                cmd.ExecuteNonQuery();
                uiResultLabel.Visible = true;
                uiResultLabel.Text = "updated Successfully";
            }
        }
