    public class MongoRead : MongoBase
    {
      public MongoRead(MongoServer server)
                : base(server)
      {
    
      }
    
           
      public override MongoDatabase Database
      {
         get { return Server.GetDatabase("myDb"); }
      }
    
      public MongoCollection Logs
      {
        get { return Database.GetCollection("logs"); }
      }
    
      private static MongoRead _instance = null;
    
      public static MongoRead Instance
      {
        get
          {
            if (_instance == null)
            {
              _instance = RegisterMongoDb();
    
            }
    
            return _instance;
          }
    
      }
    
      private static MongoRead RegisterMongoDb()
      {
          var readServer = MongoServer.Create(connectionString);
          var read = new MongoRead(readServer);
    
          var myConventions = new ConventionProfile();
          myConventions.SetIdMemberConvention(new NoDefaultPropertyIdConvention());
          BsonClassMap.RegisterConventions(myConventions, t => true);
    
          return read;
      }
    
    }
