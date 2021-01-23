    public static void Throw<T>(string message) where T : Exception
    {
    	System.Reflection.ConstructorInfo constructor = typeof(T).GetConstructor(new Type[] { typeof(string) });
    	T newException = (T)constructor.Invoke(new object[] { message });
    
    	throw newException;
    }
