    public class Something
    {
        protected IDictionary<object, Activity> Cases { get; set; }
    }
    
    public sealed class Something<T> : Something 
    {
        public Activity GetCase(T key)
        {
            return Cases[key];
        }
    
        public void AddCase(T key, Activity case)
        {
            Cases.Add(key, case);
        }
        // etc. etc.
    }
