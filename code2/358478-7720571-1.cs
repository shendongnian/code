    using System.Data.SqlClient; 
    using System.Data.SqlTypes;
.
.
.
    using (SqlConnection cn = new SqlConnection("XXXXX")) // must put a connection string to your database here
    {
        cn.Open();
        using (SqlCommand cmd = new SqlCommand("INSERT INTO Session(field1, field2) VALUES(@Value1, @Value2)"))
        {
            cmd.Parameters.AddWithValue("@Value1", 4);
            cmd.Parameters.AddWithValue("@Value2", "test");
            cmd.ExecuteNonQuery();
        }
    }
