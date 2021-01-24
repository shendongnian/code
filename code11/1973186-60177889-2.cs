    using System.Data.SqlClient;//Add this in the using statements at the top of your code.
    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" +Application.StartupPath+ @"\Database1.mdf; Integrated Security = True"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Money FROM Users WHERE Username = @username";
                    cmd.Parameters.AddWithValue("@username", "User1");
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    label1.Text = reader.GetValue(0).ToString(); //reader returns an object, you have to convert it in your type.
                    //GetValue(selected column number)
                }
                conn.Close();//This line is optional. The connection closes automatically when the using() statement ends.
            }
