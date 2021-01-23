    public abstract class Business<T> : IBusiness<T> where T : Entity
    {
        protected Data<T> data;
        
        Business<T>( T _data) 
        {
            data = _data
        }
        public IEnumerable<T> Select(DataContext db)
        {
            return data.Select(db);
        }
    }
