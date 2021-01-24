    public class InMemoryIquery : IQuery
    {
        private IHttpContextAccessor _httpContextAccessor;
        public InMemoryIquerty(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public List<Dictionary<string, string>> GetListOfDatabases(string tableName)
        {
        if(tableName != null)
            {
               _httpContextAccessor.HttpContext.Session.SetString("CalculationType", tableName);
            }
        }
    }
