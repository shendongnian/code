    using System.Reflection;
    
    void InitializeAssembly(Assembly i_Assembly)
    {
    	Type t_Class = i_Assembly.GetType("Program");
    	if (t_Class == null)
    		return; // class Program not implemented
    		
    	MethodInfo i_Main = t_Class.GetMethod("Main");
    	if (i_Main == null)
    		return; // function Main() not implemented
    
    	try 
    	{
    		i_Main.Invoke(null, null);
    	}
    	catch (Exception Ex)
    	{
    		throw new Exception("Program.Main() threw exception in\n" 
                                + i_Assembly.Location, Ex);
    	}
    }
