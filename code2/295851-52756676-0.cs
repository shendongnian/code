    dt.Rows.Clear();
            try { 
            SqlConnection con = new SqlConnection(ConnectDb.connectionstring);
           
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Admission",con);
            con.Open();
            adp.Fill(dt);
            SqlConnection con2 = new SqlConnection(ConnectDb.onlinestring);
            con2.Open();
            
            
            foreach (DataRow r in dt.Rows)
            {
                SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [Admission] WHERE ([studentName] = @SName)", con2);
                check_User_Name.Parameters.AddWithValue("@SName", r["studentName"]);
                int UserExist = (int)check_User_Name.ExecuteScalar();
                if (UserExist > 0)
                {
                    //Username exist
                    //MessageBox.Show("User Name is Already here");
                }
                else {
                SqlCommand cmd = new SqlCommand("INSERT INTO Admission(studentName, age, class, subject)VALUES(@name, @age, @class, @subject)", con2);
                cmd.Parameters.AddWithValue("@name", r["studentName"]);
                cmd.Parameters.AddWithValue("@age", r["age"]);
                cmd.Parameters.AddWithValue("@class", r["class"]);
                cmd.Parameters.AddWithValue("@subject", r["subject"]);
                cmd.ExecuteNonQuery(); 
            }
            }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
