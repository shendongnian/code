    public class Criteria<T, U>
    {
        //some filter properties...
    
        public Expression<Func<T, U>> OrderBy { get; set; }
    }
