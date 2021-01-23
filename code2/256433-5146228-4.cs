    using System;
    using System.Net;
    using System.Reflection;
    using System.ComponentModel;
    
    public class WSTest
    {
    	static void Main(string[] args)
    	{
    		if( args.Length < 1 )
    		{
    			Console.WriteLine("Usage: [method_name] ([arg0], ...)");
    			return;
    		}
    
    		MyService s = new MyService();
    
    		String methodName = args[0];
    		MethodInfo mi = s.GetType().GetMethod(methodName);
    		if( mi == null )
    		{
    			Console.WriteLine("No such method: " + methodName);
    			return;
    		}
    
    		ParameterInfo[] parameters = mi.GetParameters();
    		if( parameters.Length != (args.Length - 1) )
    		{
    			Console.WriteLine("Invalid argument count");
    			return;
    		}
    
    		Object[] methodArgs = new Object[parameters.Length];
    		for( int ix = 0; ix < parameters.Length; ix++ )
    		{
    			Type parameterType = parameters[ix].ParameterType;
    			String arg = args[ix + 1];
    			try
    			{
    				methodArgs[ix] = TypeDescriptor.GetConverter(parameterType).ConvertFrom(arg);
    			}
    			catch
    			{
    				Console.WriteLine("Unable to convert from '" + arg + "' to " + parameterType);
    				return;
    			}
    		}
    
    		// print results
    		try
    		{
    			Object result = mi.Invoke(s, methodArgs);
    			
    			// ObjectDumper code at http://stackoverflow.com/questions/1347375/c-object-dumper
    			// Alternatively, Console.WriteLine() could be used for simple value types.
    			ObjectDumper.Write(result);
    			
    			// print any out parameters
    			for( int ix = 0; ix < parameters.Length; ix++ )
    			{
    				if( parameters[ix].IsOut )
    				{
    					ObjectDumper.Write(methodArgs[ix]);
    				}
    			}
    		}
    		catch( Exception e )
    		{
    			Console.WriteLine("Error invoking method '" + methodName + "'");
    			Console.WriteLine(e);
    		}
    		Console.WriteLine("Press enter to continue...");
    		Console.ReadLine();
    	}
    }
