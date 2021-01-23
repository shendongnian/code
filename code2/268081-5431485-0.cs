    public abstract class Test
    {
        public void FooBar() // Method, capitalization, camelcase
        {
             Person fatherFigure = new Person(); // Class instance, lowercase first letter, camelcase rest.
    
        }
    
        public string Name {get; set; } // Property, capitalization, camelcase
    
        private string PrivateName {set; set; } // Private property, capitalization, camelcase
    
        public string someField; // Field, lowercase first letter, camelcase
    
        private string _someField; // Private member, prefix with _
    }
