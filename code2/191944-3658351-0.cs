    void Main()
    {
    	string strReturnValue = "";
    	Test objTest = new Test("name","type");             
    	Type dllType = typeof(MyClass);
    	if (dllType != null)
    	{
    		MethodInfo m = dllType.GetMethod("MyFunction");
    		object objdll;
    		objdll = Activator.CreateInstance(dllType);
    		object[] args = { objTest };
    		if ((m != null))
    		{                        
    			strReturnValue += (string)m.Invoke(objdll, args);                        
    		}
    	}
    }
    
    public class Test
    {
    	public Test(string s1, string s2)
    	{
    	}
    }
    
    public class MyClass
    {
    	public string MyFunction(Test t)
    	{
    		return "";
    	}
    }
