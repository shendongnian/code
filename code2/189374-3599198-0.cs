    void Main()
    {
    	Test instance = new Test();
        object[] parameters = new object[] { null };
        
        MethodInfo method = typeof(Test).GetMethod("Register");
        
        try
        {
            method.Invoke(instance, parameters);
        }
        catch
        {
            Console.Out.WriteLine("Exception");
        }
    }
    
    interface ITest { }
    interface IWindow { }
    class Plugin { }
    
    class Test : Plugin, ITest
    {
        public void Register(IWindow window)
        {
            throw new Exception("Hooah");
        }
    }
