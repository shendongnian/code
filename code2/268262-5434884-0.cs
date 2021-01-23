    public abstract class Base<TFirst, TSecond>
    {
        public Base()
        {
            if(!typeof(TFirst).IsAssignableFrom(typeof(First))
                throw new InvalidOperationException("TFirst must derive from First.");
            if(!typeof(TSecond).IsAssignableFrom(typeof(Second))
                throw new InvalidOperationException("TSecond must derive from Second.");
        }
    }
