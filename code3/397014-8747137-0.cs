    ....
    cmd3.Parameters.Add("@room_id", System.Data.SqlDbType.Int);
    
    for (int i = 0; i < arrItemsPlanner.Length; i++)
    {
        try
            {
                cmd3.Parameters["@room_id"].Value = 222;
                cmd3.ExecuteNonQuery();
            }
    ....
