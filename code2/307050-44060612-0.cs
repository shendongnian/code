     public class Parent
    {
        public string Name { get; set; }
        public string City { get; set; }
    
        //normal constructor
        public Parent()
        {
    
        }
    
        protected Parent(Parent copy)
        {
            this.Name = copy.Name;
            this.City = copy.City;
        }
    }
