        using (MySqlConnection con ...)
        {
            using (MySqlCommand cmd ...)
            {
                ... define the parameters and add them to the command, 
                ... without adding values to them yet
                con.Open();
                foreach (...)
                {
                    ... now set values of the parameters for the row
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
