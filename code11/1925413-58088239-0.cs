csharp
static void Main(string[] args)
{
    string line;
    List<string> countrys = new List<string>();
    using (StreamReader sr = new StreamReader("Countries_database.csv"))
    {
        try
        {
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine();
                var values = line.Split(',');
                Console.WriteLine(values[1]);
                countrys.Add(values[1]);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("The file could not be read {0}", ex);
        }
    
    }
}
