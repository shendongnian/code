    public class MyActionFilterAttribute: IResultFilter
    {
        public static Func<ISqlRepository> GetSqlRepo;
        private ISqlRepository _sql;
        public MyActionFilterAttribute()
        {
            _sql = GetSqlRepo();
        }
    }
