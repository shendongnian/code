    public List<BsonDocument> GetSellers(double productId)
    {
        var context = new Context();
        var filter = Builders<Product>.Filter.Eq(x => x.ProductId, productId);
        var project = Builders<Product>.Projection.Include(x => x.Sellers);
        var sellers = context.Product.Find(filter).Project(project).ToList();
        return sellers;
    }
