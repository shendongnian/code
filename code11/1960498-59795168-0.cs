csharp
public class UserService
{
    private readonly IMongoCollection<User> users;
    private readonly long userCount; //this one
    public UserService(IBookstoreDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        users = database.GetCollection<User>(settings.UsersCollectionName);
        userCount = users.Find(_ => true).CountDocuments();
    }
}
then you have to make it at least Scoped.
---
Btw it's much easier to have `MongoClient` as singleton in DI:
services.AddSingleton<IMongoClient>(s => 
    new MongoClient(Configuration.GetConnectionString("MongoDb"))
);
and then use it in all services:
public class UserService
{
    private readonly IMongoCollection<User> users;
    public UserService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("DatabaseName");
        users = database.GetCollection<User>(settings.UsersCollectionName);
    }
}
Or if you will use just one database in your app you can move IMongoDatabase to DI as well and then you don’t need to get it every time in the service constructor.
  [1]: https://mongodb.github.io/mongo-csharp-driver/2.10/getting_started/quick_tour/#mongoclient
