    public class MongoUserRepository: IUserRepository 
    {
      private readonly IMongoCollection<User> userCollection;
      
      public MongoUserRepository(IMongoCollection<User> userCollection)
      {
        this.userCollection = userCollection ?? throw new ArgumentNullException(nameof(userCollection));
      }
    
      // interface members implementation omitted for simplicity
    }
