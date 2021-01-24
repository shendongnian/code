lang-csharp
string query = "Insert into myTable Values (@myDate)";
using(SqlConnection connection = new SqlConnection(connectionString))
{
    using(SqlCommand command = new SqlCommand(query, connection))
    {
        command.Parameters.AddWithValue("myDate", dateTimePicker1.Value);       
    }
}
