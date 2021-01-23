    public class MyBaseClass
    {
        public string Name { get; private set; }
    
        public static T GimmeOne<T>(string name) where T : MyBaseClass, new()
        {
            return new T() { Name = name };
        }
    
        protected MyBaseClass()
        {
        }
    
        protected MyBaseClass(string name)
        {
            this.Name = name;
        }
    }
