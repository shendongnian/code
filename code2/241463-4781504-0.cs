    public interface IRepository<T>
     {
    	void GetAllData<T>();
     }
    
     //This needs to inherit from IRepository
     //T has to be a model class
     //V has to be a class that implements IEmployeeRepo
     public interface IEmployeeRepo<T, V> : IRepository<T> where V : EmployeeRepo where T : class
     {
    	void DoSomethingEmployeeRelated();
     }
    
     //Dont think this inheritance is correct
     public class EmployeeRepo : IEmployeeRepo<Employee, EmployeeRepo>
     {
    	public void DoSomethingEmployeeRelated()
    	{
    	
    	}
    	
    	public void GetAllData<Employee>()
    	{
    	
    	}
     }
    
     //My example model class
     public class Employee
     {
    	 public string Name {get;set;}
     }
