    var assembly = typeof (string).Assembly;
        
    var myAssemblies = new HashSet<string>
    {
     "mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    };
        			
    Assert.IsTrue(myAssemblies.Contains(assembly.FullName));
    		
