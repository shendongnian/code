    public class MyException<T> : MyException
    {
        public T Prop => (T)base._prop;
        public MyException(T prop) : base(prop)
        {
             
        }
    }
    public class MyException : Exception
    {
        protected object Prop { get; }
        public MyException(object prop)
        {
             Prop = prop;
        }
    }
