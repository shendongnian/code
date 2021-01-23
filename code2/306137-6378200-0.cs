    void Main()
    {
    	DateTime threshold = DateTime.Now.AddMinutes(-10);
    
    	IEnumerable<UserAction> unfilteredActions = new List<UserAction>
    	{
    		new UserAction { Action = "INSERT", UserName = "Craig", ExecutedOn = DateTime.Now.AddMinutes(-15) },
    		new UserAction { Action = "UPDATE", UserName = "Craig", ExecutedOn = DateTime.Now },
    		new UserAction { Action = "DELETE", UserName = "James", ExecutedOn = DateTime.Now }
    	};
    	
    	var userActions = unfilteredActions.Where(action => action.ExecutedOn > threshold).GroupBy(k => k.UserName);
    }
    
    public class UserAction
    {
    	public string Action {get;set;}
    	public string UserName {get;set;}
    	public DateTime ExecutedOn {get;set;}
    }
