        public string niceMethod()
        {
            string tDate = "";
            string ID = (Request.QueryString["nID"] ?? "0").ToString(); // Get's the nID query, incase there is no query, returns 0.
            using (SqlConnection connection = new SqlConnection("Data Source=*******;Integrated Security=False;"))
            {
                string commandtext = "SELECT bla FROM items WHERE id=@ID"; //@ID Is a parameter
                SqlCommand command = new SqlCommand(commandtext, connection);
                command.Parameters.AddWithValue("@ID", ID); //Adds the ID we got before to the SQL command
                connection.Open();
                tDate = (string)command.ExecuteScalar();
            } //Connection will automaticly get Closed becuase of "using";
            return tDate;
        }
