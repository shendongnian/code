    string query3 = "INSERT INTO furniture (room_id,member_id) VALUES (@room_id,333);";
    SqlCommand cmd3 = new SqlCommand(query3, sqlConnection3);
    sqlConnection3.Open();
    cmd3.Parameters.Add("@room_id", System.Data.SqlDbType.Int);
    for (int i = 0; i < arrItemsPlanner.Length; i++)
    {
        try
            {
                cmd3.Parameters["@room_id"].Value = 222;
                cmd3.ExecuteNonQuery();
            }
            catch
            {
                return "Error: Item could not be saved";
            }
            finally
            {
                //Fail
            }
        }
