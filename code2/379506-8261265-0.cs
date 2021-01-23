    namespace Playing.Service
    {
        public class UserService
        {
            private static readonly ILog log = LogManager.GetLogger(typeof(UserService));
            public void SaveUser(string username, string firstName, string lastName)
            {
                try
                {
                    Playing.Repository.UserRepository repository = new Repository.UserRepository();
                    repository.SaveUser(username, firstName, lastName);
                    log.DebugFormat("Saved User Info");
                }
                catch (Repository.RepositoryException rex)
                {
                    log.ErrorFormat("Repository Could Not Save User Information: {0}\n Error Message: {1}\nStack Trace: {2}", rex.Message, rex, rex.StackTrace);
                    throw new ServiceException(rex.Message, 2400);
                }
                catch (Exception ex)
                {
                    log.ErrorFormat("Could Not Save User Information: {0}\n Error Message: {1}\nStack Trace: {2}", ex.Message, ex, ex.StackTrace);
                    throw new ServiceException(ex.Message, 12400);
                }
            }
        }
        public class ServiceException : Playing.Common.BaseException
        {
            public ServiceException(string errorMessage) : base(errorMessage) {}
            public ServiceException(string errorMessage, int errorID) : base(errorMessage, errorID) {}
            public ServiceException(string errorMessage, params string[] args) : base(errorMessage, args) { }
        }
    }
    namespace Playing.Repository
    {
        public class UserRepository
        {
            private static readonly ILog log = LogManager.GetLogger(typeof(UserRepository));
            public void SaveUser(string username, string firstName, string lastName)
            {
                try
                {
                    //Save data in Database
                    log.DebugFormat("Saved User Info Into Databse");
                }
                catch (Exception ex)
                {
                    log.ErrorFormat("Could Not Save User Information: {0}\n Error Message: {1}\nStack Trace: {2}", ex.Message, ex, ex.StackTrace);
                    throw new RepositoryException(ex.Message, 3400);
                }
            }
        }
        public class RepositoryException : Playing.Common.BaseException
        {
            public RepositoryException(string errorMessage) : base(errorMessage) {}
            public RepositoryException(string errorMessage, int errorID) : base(errorMessage, errorID) {}
            public RepositoryException(string errorMessage, params string[] args) : base(errorMessage, args)  {}
        }
    }
    namespace Playing.Common
    {
        public class BaseException : Exception
        {
            public BaseException(string errorMessage) : base(errorMessage) {}
            public BaseException(string errorMessage, int errorID) : base(errorMessage) 
            { 
                StringBuilder error = new StringBuilder();
                error.Append("(");
                error.Append(errorID);
                error.Append("): ");
                error.Append(errorMessage);
                errorMessage = error.ToString();
            }
        
            public BaseException(string errorMessage, params string[] args) : base(errorMessage) 
            {
                errorMessage = string.Format(errorMessage, args);
            }
        }
    }
