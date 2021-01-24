    public class BusinessRepo
        {
            private IEnumerable<ISession> _sessions;
    
            public BusinessRepo(IEnumerable<ISession> sessions)
            {
                _sessions = sessions;
            }
    
            //This method needs to use DbConnectionString
            public PersonGeo GetPersonById(string personId)
            {
    
                var _session = _sessions.Where(a => a.Connection.Database == "DbName").FirstOrDefault();
                var value = _session.CreateCriteria<PersonGeo>()
                    .Add(Restrictions.Eq("Person_ID", personId))
                    .SetCacheable(true)
                    .SetCacheMode(CacheMode.Normal)
                    .List<PersonGeo>();
                return value.FirstOrDefault();
            }
    
    
            //This method needs to used AdminDbConnectionString
            public List<User> GetAllUsers()
            {
    
                var _session = _sessions.Where(a => a.Connection.Database == "DbName").FirstOrDefault();
                //If I debug the _session and look for connection string it is taking "DbConnectionstring (which is configured first in startup)"
                var result = _session.CreateSQLQuery("SELECT UserID,UserName,Email,IsActive FROM Users").List<User>();
                return result();
            }
        }
