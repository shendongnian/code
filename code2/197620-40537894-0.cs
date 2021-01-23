    using System;
    using System.Reflection;
    namespace TeamActivity
    {
    	class Program
        {
            static void Main(string[] args)
            {
	    		// Dynamically load assembly from the provided DLL file.
	    		Assembly CustomerAssembly = Assembly.LoadFrom( "BasicCalculations.dll" );
    			// Get a Type from the Assembly
    			Type runtimeType = CustomerAssembly.GetType( "BasicCalcuation.BasicCalc" );
    			// Get all methods from the Type.
    			MethodInfo[] methods = runtimeType.GetMethods();
    			// Loop through all discovered methods.
    			foreach ( MethodInfo method in methods )
    			{
    				Console.WriteLine( "Method name: " + method.Name );
    				// Create an array of parameters from this method.
    				ParameterInfo[] parameters = method.GetParameters();
    				// Loop through every parameter.
    				foreach ( ParameterInfo paramInfo in parameters )
    				{
    					Console.WriteLine( "\tParamter name: " + paramInfo.Name );
    					Console.WriteLine( "\tParamter type: " + paramInfo.ParameterType );
	    			}
		    		Console.WriteLine( "\tMethod return parameter: " + method.ReturnParameter );
			    	Console.WriteLine( "\tMethod return type: " + method.ReturnType );
	    			Console.WriteLine("\n");
		    	}
    			// Invoke the Type that we got from the DLL.
    			object Tobj = Activator.CreateInstance( runtimeType );
    			// Create an array of numbers to pass to a method from that invokation.
	    		object[] inNums = new object[] { 2, 4 };
	    		// Invoke the 'Add' method from that Type invokation and store the return value.
		    	int outNum = (int)runtimeType.InvokeMember( "Add", BindingFlags.InvokeMethod, null, Tobj, inNums );
	    		// Display the return value.
	    		Console.WriteLine( "Output from 'Add': " + outNum );
    			Console.WriteLine( "\nPress any key to exit." );
    			Console.ReadKey();
            }
        }
    }
