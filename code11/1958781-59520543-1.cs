    public class Sample : AuditableEntity
    {
        private string _name
        public Sample() { } // Added empty constructor here
    
        public Sample(string name)
        {
            _name = name;
        }
    
        public int Id { get; }
    
        public string Name => _name;
    }
