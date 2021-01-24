lang-csharp
internal string GetSexDescription(string sex, int id_merchant)
{
   string newSex = "";
   var builder = new ConnectionStringHelper();
   var connString = builder.getCasinoDBString(id_merchant);
   using (SqlConnection conn = new SqlConnection(connString))
   {
      conn.Open(); //<- This line here.
      string sql = "SELECT Description FROM person_gender_lookup WHERE ID = @sex";
      SqlCommand cmd = new SqlCommand(sql, conn);
      try
      {
         cmd.Parameters.Add("@Sex", SqlDbType.VarChar).Value = sex;
         newSex = cmd.ExecuteScalar().ToString();
      }
      catch(Exception ex)
      {
         Console.WriteLine(ex.Message);
      }
      return newSex;
   }
}
`cmd.ExecuteScalar()` is probably throwing an `InvalidOperationException` because you haven't opened the connection. The exception is being caught, outputted to the console, then the initial value of `newSex` is begin returned since the call to `ExecuteScalar` threw.
