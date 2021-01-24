    public class Employee
    {
        public string FirstName;
        public string SomethingElse;
        public DateTime addedDate; 
        // This is my constructor that takes one paramater (argument) 
        public Employee(string theirFirstName)
        {
            // I'm now going to save that paramater (argument) to a property of this instance 
            FirstName = theirFirstName;
            // doing this for the illustration 
            addedDate = DateTime.Now; 
        }
        // I created this constructor just incase someone forgot to provide a name when they called the code... 
        public Employee()
        {
            FirstName = "Unknown"; 
            addedDate = DateTime.Now; 
        }
    }
