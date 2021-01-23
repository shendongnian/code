    static async Task<int> FooAsync()
    {
        var t = new SimpleAwaitable();
        
        for (int i = 0; i < 3; i++)
        {
            try
            {
                Console.WriteLine("In Try");
                return await t;
            }                
            catch (Exception)
            {
                Console.WriteLine("Trying again...");
            }
        }
        return 0;
    }
