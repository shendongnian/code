    public abstract class BaseEntity<T, K> : IBaseEntity<K> where T : class, IBaseEntity<K>
    {
        public abstract K Id { get; set; }
    
        public static Table<T> Table
        {
            get { return context.GetTable<T>(); }
        }
    
        public static T SearchById(K id)
        {
            return Table.Single<T>(t => t.Id.Equals(id));
        }
    
        public static void DeleteById(K id)
        {
            Table.DeleteOnSubmit(SearchById(id));
            context.SubmitChanges();
        }
    }
