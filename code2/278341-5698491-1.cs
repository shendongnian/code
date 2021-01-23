    interface IEmployee
    {
        string Name
        {
            get;
            set;
        }
    
        int Counter
        {
            get;
        }
    }
    
    public class Employee : IEmployee
    {
        public static int numberOfEmployees;
    
        private string name;
        public string Name  // read-write instance property
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    
        private int counter;
        public int Counter  // read-only instance property
        {
            get
            {
                return counter;
            }
        }
    
        public Employee()  // constructor
        {
            counter = ++counter + numberOfEmployees;
        }
    }
