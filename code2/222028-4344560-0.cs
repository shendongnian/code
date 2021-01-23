    using System.Data;
    using System.Data.SqlClient;
    ...
    void SomeMethod() {
        using(var conn = new SqlConnection(connectionString))
        using(var cmd = conn.CreateCommand()) {
            cmd.CommandText = @"
               // some
               // tsql
               // here";
            // cmd.Paramaters.Add(...); // bobby tables
            conn.Open();
            cmd.ExecuteNonQuery(); // or Reader, etc - lots of options
        }
    }
