    string @namespace = "MyNameSpace";
    string @class = "MyClass";
    string method= "MyMEthod";
    
    var myClassType = Type.GetType(String.format("{0}.{1}", @namespace, @class));
    object instance = myClassType == null ? null : Activator.CreateInstance(myClassType); //Check if exists, instantiate if so.
    var myMethodExists = myClassType.GetMethod(method) != null;
    Console.WriteLine(myClassType); // MyNameSpace.MyClass
	Console.WriteLine(myMethodExists); // True
