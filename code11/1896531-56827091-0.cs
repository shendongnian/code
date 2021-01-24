    /// <summary>
    ///  Renames old database to new database by copying all its collected contents
    ///  ToDO: Add checks and balances to ensure all items were transferred correctly over
    ///  Disclaimer: use at own risk and adjust to your needs
    /// </summary>
    /// <param name="currentName"></param>
    /// <param name="newName"></param>
    public void renameDatabase(string currentName, string newName)
    {
    
        this.mongoClient.DropDatabase(newName); //we drop the new database in case it exists
    
        var newDb = mongoClient.GetDatabase(newName); //get an instance of the new db
    
        var CurrentDb = mongoClient.GetDatabase(currentName); //get an instance of the current db
    
        foreach (BsonDocument Col in CurrentDb.ListCollections().ToList()) //work thru all collections in the current db
        {
            string name = Col["name"].AsString; //getting collection name
    
            //collection of items to copy from source collection
            dynamic collectionItems = CurrentDb.GetCollection<dynamic>(name).Find(Builders<dynamic>.Filter.Empty).ToList();
    
            //getting instance of new collection to store the current db collection items
            dynamic destinationCollection = newDb.GetCollection<dynamic>(name);
    
            //insert the source items into the new destination database collection
            destinationCollection.InsertMany(collectionItems);
        }
    
        //removing the old datbase
        this.mongoClient.DropDatabase(currentName);
    }
