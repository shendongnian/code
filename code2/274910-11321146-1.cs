    // entity base
    public class MongoEntity {
        public ObjectId _id { get; set; }
    }
    
    //user entity
    public class Users : MongoEntity {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    // simple repository
    public class Repository {
        private MongoDatabase _db;
        public MongoDatabase Database { get; private set; }
        public Repository(string constr, string dbname) {
            var server = MongoServer.Create(constr);
            _db = server.GetDatabase(dbname);
            Database = _db;
        }
        private MongoCollection<T> GetCollection<T>() where T : MongoEntity {
            return _db.GetCollection<T>(typeof(T).Name);
        }
        public IEnumerable<T> List<T>() where T : MongoEntity {
            return GetCollection<T>().FindAll();
        }
        public IEnumerable<T> List<T>(Expression<Func<T, bool>> exp) where T : MongoEntity {
            return GetCollection<T>().AsQueryable<T>().Where(exp);
        }
        public T Single<T>(Expression<Func<T, bool>> exp) where T : MongoEntity {
            return List<T>(exp).SingleOrDefault();
        }
        public void Insert<T>(T entity) where T : MongoEntity {
            GetCollection<T>().Insert<T>(entity);
        }
        public void Insert<T>(ICollection<T> entities) where T : MongoEntity {
            GetCollection<T>().InsertBatch(entities);
        }
        // Update, Delete method etc ...
        
    }
    
    // example
    var repository = new Repository("test", "mongodb://localhost");
    repository.Single<Users>(u => u.UserName == "myUserName");
