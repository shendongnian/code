    public bool UpdateContactDetail(string ContactId,string ColumnsValue, BsonDocument document)
            {
                bool success = false;
                try
                {                    
                for (int i = 0; i < document.ElementCount; i++)
                {
                  MongoClient client = new MongoClient(ConnectionString);
                  MongoServer objServer = client.GetServer();
                  var DB = objServer.GetDatabase(DatabaseName);
                  var collection = DB.GetCollection("EmailContacts");
                  var searchQuery = Query.EQ("_id", ObjectId.Parse(ContactId));
                  var sortBy = SortBy.Null;
                  var update = Update.Set(document.ToArray()[i].Name, document.ToArray()[i].Value.ToString());
                  collection.FindAndModify(searchQuery, sortBy, update);
                }
                success = true;
                }
                catch (MongoConnectionException) { return false; }
    
                catch (Exception ex)
                {
                    ExceptionHandling.InsertExceptionMessage("MongoDB", this.GetType().Name, 
                    System.Reflection.MethodBase.GetCurrentMethod().Name, ex, 1);
                    return false;
                }
            }
