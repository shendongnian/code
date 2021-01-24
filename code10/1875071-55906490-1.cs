void PrintRows(SqlConnection connection)
{
    using (connection)
    {
        SqlCommand command = new SqlCommand(
          "SELECT CategoryID, CategoryName FROM Categories;",
          connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                    reader.GetString(1));
            }
        }
        else
        {
            Console.WriteLine("No rows found.");
        }
        reader.Close();
    }
}
in your situation you should modify your code like this :
conn.Open();
var cmd = new SqlCommand($"SELECT date, subject FROM table WHERE table.id > 5", conn) 
while (reader.Read())
 {
    rtb.AppendText(reader.GetDateTime(0).ToShortDateString() + "\n" +reader.GetString(1));
 }
