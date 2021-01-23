    public void UpdateUserAnimals(Guid userId, string[] animals)
    {
        using (SqlConnection conn = new SqlConnection("connectionstring..."))
        {
            using (SqlCommand cmd = new SqlCommand("Insert Into UserAnimals(UserId, Animals) values (@UserId, @Animal)"))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@UserId", userId);
                foreach(string animal in animals)
                {
                    cmd.Parameters.AddWithValue("@Animal", animal);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
