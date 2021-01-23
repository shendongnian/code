    public interface IEmployee
    {}
    
    public abstract class BaseApplication<T> where T:IEmployee{ 
    	public T IEmployee{ get; set; } 
    } 
     
    public class ExistingEmployee : IEmployee {}
    public class NewEmployee : IEmployee {}
    
    public class Application : BaseApplication<ExistingEmployee> {} 
     
    public class NewApplication : BaseApplication<NewEmployee> {} 
