    public abstract class Person
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
    
    public partial class Teacher : Person
    {   
        public string School { get; set; }
    }
    
    public partial class Student : Person
    {
        public string YearLevel { get; set; }
    }
    
    public partial class Parent : Person
    {
        public string Blagh { get; set; }
    }
