    class EntityBase<T> where T : IComparable<T>
    {
        public virtual void Method(T t)
        {
            // ...
        }
    }
    
    class Entity<T> : EntityBase<T>
       where T : IComparable<T>, ISomethingElse
    {
        public override void Method(T t)
        {
            // ... can use ISomethingElse features
        }
    }
