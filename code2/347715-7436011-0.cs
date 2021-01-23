    public class Comment
    {
        public string Message {get;set;}
        public Employee {get;set;}
        public Meeting {get;set;}
    }
    
    public class Employee
    {
        //public List<Comment> Comments { get; set; } <- why does this matter?
    }
    
    public class Meeting
    {
        //public List<Employee> Employees { get; set; }  <- why does this matter?
        public List<Comment> Comments { get; set; } 
    }
