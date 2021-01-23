    static void Insert()
    {
        try
        {
            string connectionString =
            "server=.;" +
            "initial catalog=MyDatabaseName;" + //here you write database name where your NyhedTB table is
            "user id=sa;" + //user name to connect to database
            "password=sa123"; //password
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                  new SqlCommand("INSERT INTO NyhedTB (NyhedDato, NyhedTitel, NyhedTekst) VALUES (@NyhedDato, @NyhedTitel, @NyhedTekst)", conn))
                {
                    //all "things" in your sql command what beggins with @ 
                    //means that it is parameter and you need to pass values for these parameters: 
                    //For @NyhedDato parameter you set text from your textbox
                    cmd.Parameters.AddWithValue("@NyhedDato", txtDate.Text);
                
                    //For @NyhedTitel parameter you set text from title textbox
                    cmd.Parameters.AddWithValue("@NyhedTitel", txtTitle.Text);
                
                    //For @NyhedTekst parameter you set text from content textbox
                    cmd.Parameters.AddWithValue("@NyhedTekst", txtContent.Text);
                    //Execute insert command and get how many records was efected, in this case it should be rows = 1 because you inserting just one record
                    int rows = cmd.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException ex)
        {
           //Log exception
           //Display Error message
        }
    }
