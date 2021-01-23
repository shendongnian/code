    public class Employee 
    {
        public string Name { set; get; }
        virtual public Employee Manager { set; get; }
    
        public Employee()
        {
     
        }
    }
