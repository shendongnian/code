    static async Task Main(string[] args)
    {
        await doSomeStuff();
    }
    
    public static async Task doSomeStuff() // <--- make it Task so it can be await'ed
    {
        var connString = "Server=localhost;User ID=root;Password=password;Database=mysql";
    
        using (var conn = new MySqlConnection(connString))
        {
            await conn.OpenAsync();
    
            using (var cmd = new MySqlCommand("SELECT host FROM mysql.user", conn))
            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                    Console.WriteLine(reader.GetString(0));
        }
    
    
        Console.WriteLine("Finished!");
        Console.ReadKey();
    }
  
