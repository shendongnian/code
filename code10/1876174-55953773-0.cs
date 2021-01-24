    string[] things = new[]{"foo", "bar", "baz");
    SomeSqlCommand sql = new SomeSqlCommand("INSERT INTO table(a, b) VALUES(@a, @b)", "some connection string");
    sql.Parameters.AddWithValue("@a", "fixed value");
    sql.Parameters.AddWithValue("@b", "dummy value - will change in loop");
    sql.Connection.Open();
    foreach(string thing in things)
    {
      sql.Parameters["@b"].Value = thing;
      sql.ExecuteNonQuery();
    }
    sql.Connection.Close();
