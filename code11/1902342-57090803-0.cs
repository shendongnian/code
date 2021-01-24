    delegate void RemoveEventDelegate(Entity entity);
    public class Entity
    {
        public event RemoveEventDelegate OnEntityDeleted;
        public virtual bool IsEntityDeleted { get; internal set; }
    
        public void DeleteEntity()
        {
            // Other logics...
            IsEntityDeleted = true;
            if (OnEntityDeleted != null)
            {
                OnEntityDeleted(this);
            }
        }
    }
