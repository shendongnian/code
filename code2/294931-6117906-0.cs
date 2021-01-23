    /// <summary>
    /// A generic class that provides CRUD operations againts a certain database
    /// </summary>
    /// <typeparam name="Context">The Database context</typeparam>
    /// <typeparam name="T">The table object</typeparam>
    public class DataContextWrapper<Context> where Context : DataContext, new()
    {
        Context DataContext;
        
        /// <summary>
        /// The name of the connection string variable in web.config
        /// </summary>
        string ConnectionString
        {
            get
            {
                return "Connection String";
            }
        }
        /// <summary>
        /// Class constructor that instantiates a new DataContext object and associates the connection string
        /// </summary>
        public DataContextWrapper()
        {
            DataContext = new Context();
            DataContext.Connection.ConnectionString = ConnectionString;
        }
       
        protected IEnumerable<T> GetItems<T>([Optional] Expression<Func<T, bool>> query) where T : class, new()
        {
            //get the entity type
            Type entity = typeof(T);
            //get all properties
            PropertyInfo[] properties = entity.GetProperties();
            Expression<Func<T, bool>> isRowActive = null;
            //we are interested in entities that have Active property ==> to distinguish active rows
            PropertyInfo property = entity.GetProperties().Where(prop => prop.Name == "Active").SingleOrDefault();
            //if the entity has the property
            if (property != null)
            {
                //Create a ParameterExpression from
                //if the query is specified then we need to use a single ParameterExpression for the whole final expression
                ParameterExpression para = (query == null) ? Expression.Parameter(entity, property.Name) : query.Parameters[0];
                var len = Expression.PropertyOrField(para, property.Name);
                var body = Expression.Equal(len, Expression.Constant(true));
                isRowActive = Expression.Lambda<Func<T, bool>>(body, para);
            }
            
            if (query != null)
            {
                //combine two expressions
                var combined = Expression.AndAlso(isRowActive.Body, query.Body);
                var lambda = Expression.Lambda<Func<T, bool>>(combined, query.Parameters[0]);
                return DataContext.GetTable<T>().Where(lambda);
            }
            else if (isRowActive != null)
            {
                return DataContext.GetTable<T>().Where(isRowActive);
            }
            else
            {
                return DataContext.GetTable<T>();
            }
        }
    }
