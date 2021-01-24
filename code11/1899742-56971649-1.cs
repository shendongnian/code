    public static class BaseModule
    {    
        public static Write(string text, string source)
        {
            OtherStaticClass.Log(source, text);
        }
    }
    
    internal abstract class Module
    {
    	public abstract Source { get; };
    	
    	public void Write(string text)
    	{		
    		BaseModule.Write(text, Source);		
    	}	
    }	
    
    internal class ModuleA : Module
    {	
    	public override Source => "A";
    }
    
    internal class ModuleB : Module
    {	
    	public override Source => "B";
    }
