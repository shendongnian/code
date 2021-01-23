    using (MySqlCommand command = new MySqlCommand("SELECT column1, column2, column FROM tablename", conn))
    {
        try
        {
            conn.Open();
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                    reader.Read();
                    var someString = reader["column1isastring"].ToString();
                    var whatever = (Int32)reader["column2isInt32"];
            } //reader closes and disposes here
        }
        catch (Exception ex)
        {
            //log this exception
        }
        finally
        {
            conn.Close();
        }
    } //conn gets closed and disposed of here
