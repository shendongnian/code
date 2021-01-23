    {
        String connectionString = Properties.Settings.Default.Database;
        String selectString = "select artikelnummer, omschrijving from Artikels";
        SqlDataReader reader = null;
        using (SqlConnection connection = new SqlConnection(connectionString))
        /* you also need to associate the connection with the command */
        using (SqlCommand command = new SqlCommand(selectString, connection))
        {
            connection.Open();
            reader = command.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                String item = String.Empty;
                item = Convert.ToString(reader["Artikelnummer"]) + "\t" + Convert.ToString(reader["Omschrijving"]);
                x++;
                listboxGeselecteerd.Items.Add(item);
            }            
        }
    }
