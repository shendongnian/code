new MongoClientSettings()
{
	ConnectionMode = ConnectionMode.ReplicaSet,
	Credential = MongoCredential.CreateCredential("admin", Username, Password),
	ReplicaSetName = "ReplicaSetName",
	Servers =  new List<MongoServerAddress>(){new MongoServerAddress("server", 27017), new MongoServerAddress("server2", 27017)}.ToArray(),
	ApplicationName = "AppName",
}
