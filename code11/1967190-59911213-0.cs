"mongodb://aaa:123@m.com:27017,m1.com:37017,m2.com:27017/dbtest?replicaSet=myRepl"
**Recommendation**
Instead of using a connection string like above, I would recommend using the native C# variables to connect to replica set. ConnectionMode specifies in the setting whether thats a `ReplicaSet` or `Direct`.
    var mongoClientSettings = new MongoClientSettings()
    {
        ConnectionMode = ConnectionMode.ReplicaSet,
        Credential = MongoCredential.CreateCredential("admin", "user", "pass"),
        ReplicaSetName = "ReplicaSetName",
        Servers = new List<MongoServerAddress>() { new MongoServerAddress("host", 27017), new MongoServerAddress("host2", 27017) }.ToArray(),
        ApplicationName = "NameOfYourApplicatino",
    };
    MongoClient client = new MongoClient(mongoClientSettings);
Since the client is thread safe, you can use that as a global variable as well.
