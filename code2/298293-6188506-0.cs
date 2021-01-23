    interface IBase { }
    class X : IBase { static string m = "x";}    
    class Y : IBase { static string m = "y";}    
    class Z : IBase { static string m = "z";}
        
    static void Main()
    {
    	Type[] arr = { typeof(X), typeof(Y), typeof(Z) };
    	foreach (Type t in arr)
    	{
    		FieldInfo fieldInfo = t.GetField("m", 
                    BindingFlags.Static | BindingFlags.NonPublic);
    		Console.WriteLine(fieldInfo.GetValue(null));
    	}
    }
