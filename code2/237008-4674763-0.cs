    public class Dao 
    {
        void Save();
    }
    
    public class GenericDao<T> : Dao
    {
        public virtual T Save(T) {...}
    }
    
    // error here because GenericDao does not implement Dao.
    protected dynamic Dao { get { return new GenericDAO<Attachment>(); } }
