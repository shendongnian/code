    public async Task<List<Product>> getAllProducts(){
        var collection = await getCollection("produits").Find(new BsonDocument()).ToListAsync();
        List<Product> all = new List<Product>();
        foreach(var doc in collection){
            all.Add(BsonSerializer.Deserialize<Product>(doc));
        }
        return all;
    }
