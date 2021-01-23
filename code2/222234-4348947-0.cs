    public abstract class BaseApplication {
     public Employee Employee{ get; set; }
    }
    
    public class Application : BaseApplication
    {
     public new ExistingEmployee Employee{ get{return (ExistingEmployee)base.Employee;} set{base.Employee=value; }}
    }
    
    public class NewApplication : BaseApplication
    {
     public new NewEmployee Employee{ get{return (NewEmployee)base.Employee;} set{base.Employee=value; }}
    }
