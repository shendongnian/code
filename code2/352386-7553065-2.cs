    public class Person
    {
        public Person()
        {
            // This constructor will create a "nobody"
        }
        
        public Person(string name)
        {
            // Proper initialization
            this.Name = name;
            _isNobody = false;
        }
        
        public string Name { get; set; }
        
        public virtual bool IsNobody
        {
            get 
            {
                return String.IsNullOrEmpty(this.Name) == false;
            }
        }
        
        // TODO: Maybe override Equals/==/GetHashCode to take IsNobody into account
    }
