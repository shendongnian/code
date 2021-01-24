    public interface MyInterface 
    {
        TimeSpan TimeStamp { get; } //or whatever type your are using for your TimeStamp property
    }
    
    var collection = this.GetDatabaseConnection().GetCollection<MyInterface> 
        (collectionName);
    var filter = Builders<MyInterface>.Filter.Where(result => result.TimeStamp >= 
        startTime && result.TimeStamp <= endTime);
    List<MyInterface> queryData = collection.Find<MyInterface>(filter,null).ToList();
