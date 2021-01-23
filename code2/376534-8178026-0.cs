    public class User
    {
        public string Id { get; set; }
        public List<Action> Actions { get; set; }
    }
    public class Action
    {
        public DateTime CreatedOn { get; set; }
    }
    public class ActionCreatedOnResult
    {
        public DateTime CreatedOn { get; set; }
    }
    public class Users_ActionCreatedOn : AbstractIndexCreationTask<User, ActionCreatedOnResult>
    {
        public Users_ActionCreatedOn()
        {
            Map = users => from user in users
                           from action in user.Actions
                           select new
                                      {
                                          action.CreatedOn
                                      };
            Store(x => x.CreatedOn, FieldStorage.Yes);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            using (var documentStore = new DocumentStore{ Url = "http://localhost:8080/" })
            {
                documentStore.Initialize();
                IndexCreation.CreateIndexes(typeof(Users_ActionCreatedOn).Assembly, documentStore);
                using (var documentSession = documentStore.OpenSession())
                {
                    var result = documentSession.Query<ActionCreatedOnResult, Users_ActionCreatedOn>()
                        .OrderByDescending(x => x.CreatedOn)
                        .AsProjection<ActionCreatedOnResult>()
                        .FirstOrDefault();
                }
            }
        }
    }
