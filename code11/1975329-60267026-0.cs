csharp
    public static async Task<string> getAllProducts()
    {
        var collection = db.GetCollection<object>("produits");
        var all = new List<object>();
        using (var cursor = await collection.FindAsync("{}"))
        {
            while (await cursor.MoveNextAsync())
            {
                foreach (var doc in cursor.Current.ToArray())
                {
                    all.Add(doc);
                }
            }
        }
        return Newtonsoft.Json.JsonConvert.SerializeObject(all);
    }
