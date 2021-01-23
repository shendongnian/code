        public string niceMethod()
        {
            string ID = Request.QueryString["nID"] ?? "0"; // Get's the nID query, incase there is no query, returns 0.
            using (SqlConnection connection = new SqlConnection("Data Source=*******;Integrated Security=False;"))
            {
                string commandtext = "SELECT bla FROM items WHERE id=@ID"; //@ID Is a parameter
                SqlCommand command = new SqlCommand(commandtext, connection);
                command.Parameters.AddWithValue("@ID", ID); //Adds the ID we got before to the SQL command
                connection.Open();
                string tDate = (string)command.ExecuteScalar();
                connection.Close();
                return tDate;
            }
        }
