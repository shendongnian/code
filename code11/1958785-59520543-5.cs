    public class Sample : AuditableEntity
    {
        private string _name; //now EF has access to this property with the Mapping added
        public Sample(string name)
        {
            _name = name;
        }
    
        public int Id { get; } 
    
        public string Name => _name;
    }
