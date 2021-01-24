    static void Main(string[] args)
    {
        // Open database (or create if not exits)
        using (var db = new LiteDatabase(@"MyData.db"))
        {
            // Get user collection
            var users = db.GetCollection<User>("users");
                var id = Guid.Parse("8dd0997e-42b1-432d-820e-4637dd08fa2e");
                //var userById = users.FindOne(x => x.Id == id);
                var userById = users.FindById(id);
                if (id != userById.Id)
                   Console.WriteLine("Error!");
        }
    }
