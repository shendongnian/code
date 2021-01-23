    public abstract class DomainObject {
        // Some properties
    
        protected abstract dynamic Dao { get; }
    
        public virtual void Save() {
            var dao = Dao;
            dynamic d = this; //Forces type for Save() to be resolved at runtime
            dao.Save(d);
        }
    }
