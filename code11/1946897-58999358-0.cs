`
public bool IsConnectionStringValid(string cs)
{
    try
    {
         using (MySqlConnection conn = new MySqlConnection(cs))
         {
             conn.Open();
             return true;
         }
    }
    catch
    {
        return false;
    }
}
`
Although I have to admit, in all my years of developing in C#, I've never used anything like this. Normally, as people have said in the comments, you already know before runtime that your connection string is valid and working.
