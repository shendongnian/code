csharp
Console.WriteLine("Connecting");
using (var conn = new SqlConnection(@"server=np:<IP>\SQLEXPRESS;user id=sa;password=<PASSWORD>;database="))
{
    Console.WriteLine("Try to open connection");
    conn.Open();
    Console.WriteLine("Connection opened");
}
Console.ReadLine();
But what is still interesting, why .Net Framework 4.7.1 does not need to do so. Any suggestions?
