    class EntityBase
    {
        public virtual void Method<T>(T t)
          where T : IComparable<T>
        {
            // ...
        }
    }
    
    class Entity : EntityBase
    {
        public override void Method<T>(T t)
            // Error: Constraints may not be
            // repeated on overriding members
        where T : IComparable<T>, ISomethingElse
        {
            // ...
        }
    }
