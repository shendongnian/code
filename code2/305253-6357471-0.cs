    public class FastTestAttribyte :TimeoutAttribute
    {
        protected string categoryName;
    
        public FastTestAttribyte (int timeout):base(timeout)
       {
           categoryName = "FastTest";
       }
    
        public string Name { get return categoryName; }
    }
