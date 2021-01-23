    public interface IEmployee
    { }
    
    public class Employee1 : IEmployee
    { }
    
    public class Employee2 : IEmployee
    { }
    
    public abstract class ApplicationBase
    {
        public abstract IEmployee Employee { get; set; }
    }
    
    public class App1 : ApplicationBase
    {
        public override IEmployee Employee
        {
            get { return new Employee1(); }
            set;
        }
    }
    
    public class App2 : ApplicationBase
    {
        public override IEmployee Employee
        {
            get { return new Employee2(); }
            set;
        }
    }
