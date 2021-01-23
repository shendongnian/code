            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Table";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            connection.Open();
            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);           
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();           
            }
        }
