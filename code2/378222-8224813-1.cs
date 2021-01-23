    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string connectionString =
                "server=SQLServer;" +         // SQLServer is your SQL server machine
                "initial catalog=employee;" + // employee is your database
                "user id=sa;" +               // sa is the login to connect the database
                "password=sa123";             // sa123 is the password of the login
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO [NyhedTB] ([NyhedDato], [NyhedTitel], [NyhedTekst]) " +
                    "VALUES (@NyhedDato, @NyhedTitel, @NyhedTekst)", conn))
                {
                    cmd.Parameters.AddWithValue("@NyhedDato", textBoxDate.Text);
                    cmd.Parameters.AddWithValue("@NyhedTitel", textBoxTitle.Text);
                    cmd.Parameters.AddWithValue("@NyhedTekst", textBoxBody.Text);
    
                    int rows = cmd.ExecuteNonQuery();  // Inserted rows number
                }
            }
        }
        catch (SqlException ex)
        {
            //Log exception
            //Display Error message
        }
    }
