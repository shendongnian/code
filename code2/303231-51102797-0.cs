    abstract class FooBase<T>
    {
        protected FooBase()
        {
            if (typeof(T) != GetType())
            {
                throw new InvalidOperationException();
            }
        }
    }
