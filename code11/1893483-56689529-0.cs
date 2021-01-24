lang-csharp
private async Task<int> GetProp1()
{
    int prop1 = 0;
    using (SqlConnection con = new SqlConnection("connectionString"))
    {
        await con.OpenAsync();
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = "Select ...";
            cmd.CommandType = CommandType.Text;
            prop1 = await cmd.ExecuteScalarAsync();
        }
    }
    return prop1;
}
That said, if the various select statements are all being executed against the same database you could just execute multiple statements at once, use `ExecuteReader` and `NextResult`.
Something like this...
lang-csharp
private async Task<MyObj> GetMyObjAsync()
{
   MyObj obj = new MyObj();
   using (SqlConnection con = new SqlConnection("connectionString"))
   {
      await con.OpenAsync();
      string sqlStatements = @"
SELECT Prop1 FROM Table1;
SELECT Prop2 FROM Table2;
SELECT Prop3 FROM Table3;
--etc";
      using (SqlCommand cmd = new SqlCommand(sqlStatements, con))
      using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
      {
         if (await reader.ReadAsync()) 
         {
            obj.Prop1 = Convert.ToInt32(reader["Prop1"]);
         }
         await reader.NextResultAsync();
         if (await reader.ReadAsync()) 
         {
            obj.Prop2 = Convert.ToInt32(reader["Prop2"]);
         }
         await reader.NextResultAsync();
         if (await reader.ReadAsync()) 
         {
            obj.Prop3 = Convert.ToInt32(reader["Prop3"]);
         }
         // etc...
      }
   }
   return obj;
}
This way, you only have one connection to the database instead of having to create a separate connection per property on `MyObj`.
