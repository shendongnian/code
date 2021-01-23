    public class Criteria<T>
    {
        //some filter properties...
    
        public Expression OrderBy { get; set; }
        
        public void CreateOrdering<U>(Expression<Func<T, U>> value)
        {
            OrderBy = value;
        }
    }
