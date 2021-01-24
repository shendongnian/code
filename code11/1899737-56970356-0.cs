    public abstract class BaseModule
    {
    	public string UsedSource { get; set; }
    	
    	public void Write(string text)
    	{
    		OtherStaticClass.Log(UsedSource, text);
    	}	
    }
    
    public class ModuleA : BaseModule
    {
    	public ModuleA()
    	{
    		UsedSource = "A";
    	}	
    }
    
    public class ModuleB : BaseModule
    {
    	public ModuleB()
    	{
    		UsedSource = "B";
    	}
    }
