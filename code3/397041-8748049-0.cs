	public class Example
	{
	  public Boolean Condition {get; set;}
	  public Double ConditionValue {get; set;}
	  
	  public void DoSomthing()
	  { 
               Verify.That(!Condition && ConditionValue>5);
               ...
	  }
	}
