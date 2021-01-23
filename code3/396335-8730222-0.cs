    public class MyClass
    {
        public int? Id { get; }
    
        public MyClass()
        {
            Initialize();
        }
        public MyClass(int id)
        {
            Initialize(id);
        }
    
        public Reset()
        {
            Initialize();
        }
        private Initialize(int? id = null)
        {
            // initialize values here instead of the constructor
            Id = id;
        }
    }
