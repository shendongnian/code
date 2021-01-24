    public abstract class BaseClass
    {
        public T GetSlightlyModifiedInstance<T>() where T : new, BaseClass
        {
            return new T(); // Do whatever there
        }
    }
