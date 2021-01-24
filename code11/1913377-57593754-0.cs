    public static List<string> GetIds()
    {
        var context = new MyContext();
        var builder = Builders<MyCollection>.Filter;
        var filter = builder.Empty;
        var ids = context.MyCollection.Find(filter).Project(x => x.Id.ToString()).ToList();
        return ids;
    }
