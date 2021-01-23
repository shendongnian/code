    public class ManagerBase
    {
    }
    class ManagerRepository
    {
        private Dictionary<Type, Func<SqlDataReader, ManagerBase>> _ManagerCreateDelegates;
        public ManagerRepository()
        {
            _ManagerCreateDelegates = new Dictionary<Type, Func<SqlDataReader, ManagerBase>>();
        }
        public void RegisterCreate<T>(Func<SqlDataReader, ManagerBase> create)
            where T : ManagerBase
        {
            _ManagerCreateDelegates[typeof(T)] = create;
        }
        public ManagerBase GetManager(int managerID, bool withUsers)
        {
            SqlDataReader reader;
            reader = null;// TODO: obtain a data reader from somewhere...
            Type typeOfManager = this.DetermineManagerType(reader);
            Func<SqlDataReader, ManagerBase> create;
            if (_ManagerCreateDelegates.TryGetValue(typeOfManager, out create))
            {
                return create(reader);
            }
            else
            {
                throw new InvalidOperationException(string.Format("No create delegate has been registered for type [{0}].", typeOfManager.FullName));
            }
        }
        private Type DetermineManagerType(SqlDataReader reader)
        {
            // TODO: implement logic that uses the data reader to decide which type of Manager object to create
            throw new NotImplementedException();
        }
    }
    public class ManagerSomething1 : ManagerBase
    {
        public ManagerSomething1(SqlDataReader reader)
        {
            // TODO: implement logic to construct ManagerSomething1 given a data reader
        }
    }
    public class ManagerSomething2 : ManagerBase
    {
        public ManagerSomething2(SqlDataReader reader)
        {
            // TODO: implement logic to construct ManagerSomething1 given a data reader
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // create a ManagerRepository somewhere
            ManagerRepository repository = new ManagerRepository();
            // register create delegates for each type of Manager
            repository.RegisterCreate<ManagerSomething1>(dr => new ManagerSomething1(dr));
            repository.RegisterCreate<ManagerSomething2>(dr => new ManagerSomething2(dr));
            // use the repository
            int managerID = 5;
            bool withUsers = false;
            ManagerBase manager = repository.GetManager(managerID, withUsers);
        }
    }
