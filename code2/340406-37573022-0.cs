    public abstract class GenericRepository<T> : ApiController,IGenericRepository<T> where T : class
    {
        
        string sqlstr = @"
            SELECT COLUMN_NAME
            FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
            WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1
            AND TABLE_NAME = '" + typeof(T).ToString() + "' AND TABLE_SCHEMA = 'dbo'";
        private Entities _entities = new Entities();
        public  virtual IQueryable<T> GetAll()
        {
            DbSqlQuery<T> queryTest = _entities.Set<T>().SqlQuery(sqlstr);
