    class BaseClass
    {
    	public void MethodA() // invoking this will correctly log "SubClass MethodB" followed by "BaseClass MethodB"
    	{
    		MethodB();
    	}
    	public virtual void MethodB()
    	{
    		Debug.Log("BaseClass MethodB");
    	}
    }
    
    class SubClass : BaseClass
    {
    	public override void MethodB()
    	{
    		Debug.Log("SubClass MethodB");
    		base.MethodB();
    	}
    }
