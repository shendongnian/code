csharp
List<string> skillsList = new List<string>();
using (MySqlConnection cons = new MySqlConnection(MyConString))
{
   string query = "SELECT DISTINCT(skill2) AS skills FROM agentdetails";
   var command = new MySqlCommand(query, cons);
   cons.Open();
   var reader = command.ExecuteReader();
   reader.Read();
   while (reader.Read())
   {
      skillsList.Add(reader["skill"].ToString());
   }
}
string skills = $"''{string.Join("'',''", skillsList)}''";
