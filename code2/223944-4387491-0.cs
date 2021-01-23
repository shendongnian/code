            using (SqlCommand command = new SqlCommand("SELECT * FROM Dogs1 WHERE Name LIKE @Name", connection))
            {
                string dogName = "Mc'Dougal";
                //
                // Add new SqlParameter to the command.
                //
                command.Parameters.Add(new SqlParameter("Name", dogName));
                //
                // Read in the SELECT results.
                //
                SqlDataReader reader = command.ExecuteReader();
            }
