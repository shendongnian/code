    public class Home
    {
        public virtual string GetClassType { get; }
    }
    public class Home<T> : Home
        where T : class
    {
        public override string GetClassType
        {
            get{ return T.ToString() } 
        }
        ...
    }
