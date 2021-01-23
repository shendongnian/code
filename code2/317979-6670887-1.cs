    void Main()
    {
    	var request = new WorkRequest();
    	request.FirstName = "joe";
    	request.LastName ="smith";
    	
    	var employeeRequest = RequestFactory.Create<EmployeeRequest>(request);
    	
    	System.Diagnostics.Debug.Assert(employeeRequest.FirstName == request.FirstName);
    }
    public class RequestFactory
    {
    	public static T Create<T>(Request request)
    		where T : Request, new()
    	{
    		return (T)Activator.CreateInstance(typeof(T), request);
    	}
    }
    
    public abstract class Request
    {
    	protected Request() {}
    	
    	protected Request(Request request)
    	{
    		this.FirstName = request.FirstName;
    		this.LastName = request.LastName;
    	}
    	
    	public string FirstName {get;set;}
    	
    	public string LastName {get;set;}
    }
    
    public class EmployeeRequest : Request
    {
    	public EmployeeRequest(){}
    	
    	public EmployeeRequest(Request request) 
    		: base(request)
    	{
    	
    	}
    }	
    
    public class WorkRequest : Request
    {
    	public WorkRequest(){}
    	
    	public WorkRequest(Request request) 
    		: base(request)
    	{
    	
    	}
    }	
