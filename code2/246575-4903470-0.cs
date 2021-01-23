    public class SpecElement
    {
    	public SpecElement (Action action, string name)
    	{
    	  Name = name;
  	    this.ActionToTake = action;
  	  }
    
    	public Action ActionToTake {get; set;}
    	public string Name {get; set; }
    
  	  public bool Execute()
    	{
    	  try 
    	  {
      	   this.ActionToTake();
	         return true;
          } 
    	  catch (Exception) 
    	  {
             return false;
          }
       }
    }
