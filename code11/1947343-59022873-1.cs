    public class Option<T>
        where T: class
    {
        protected T value;
        public bool IsSome => value != default(T);
    }
    public class Some<T> : Option<T>
        where T: class
    {
        public Some(T value) => base.value = value;
        public T Value => base.value;
    }
    public class None<T> : Option<T>
        where T: class
    {
       
    }
