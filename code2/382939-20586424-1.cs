    using System;
    using System.Reflection;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;
    class Person
    {
        private string SayInternalSecure()
        {
	         if (!PrivacyHelper.IsInvocationAllowed<Person>())
		        throw new Exception("you can't invoke this private method");
	         return "Internal Secure";
        }
	
        private string SayInternal()
        {
	         return "Internal";
        }
	
        public string SaySomething()
        {
	         return "Hi " + this.SayInternal();
        }
	
        public string SaySomethingSecure()
        {
          	return "Hi " + this.SayInternalSecure();
        }
	
        public void BeingCalledBy()
        {
                Console.WriteLine("I'm being called by: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }
    }
    public class MethodBaseComparer : IEqualityComparer<MethodBase> 
    {
         private string GetMethodIdentifier(MethodBase mb)
         {
	      return mb.Name + ":" + String.Join(";", mb.GetParameters().Select(paramInfo=>paramInfo.Name).ToArray());
         }
         public bool Equals(MethodBase m1, MethodBase m2) 
         {
            //we need something more here, comparing just by name is not enough, need to take parameters into account
	        return this.GetMethodIdentifier(m1) == this.GetMethodIdentifier(m2);
         }
         public int GetHashCode(MethodBase mb) 
         {
                 return this.GetMethodIdentifier(mb).GetHashCode();
         }
    }
    class PrivacyHelper
    {
	static Dictionary<Type, MethodBase[]> cache = new Dictionary<Type, MethodBase[]>();
	public static bool IsInvocationAllowed<T>()
	{
		Type curType = typeof(T);
		if (!cache.ContainsKey(curType))
		{
			cache[curType] = curType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).ToArray();
		}
		//StackTrace.GetFrame returns a MethodBase, not a MethodInfo, that's why we're falling back to MethodBody
		MethodBase invoker = new StackTrace().GetFrame(2).GetMethod();
		return cache[curType].Contains(invoker, new MethodBaseComparer());
	}
    }
    public class App
    {
	public static void CheckCaller()
	{
		Person p = new Person();
		
		Console.WriteLine("- calling via delegate");
		Action action = p.BeingCalledBy;
		action();
		
		Console.WriteLine("- calling via reflection");
		MethodInfo method = typeof(Person).GetMethod("BeingCalledBy", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		Console.WriteLine(method.Invoke(p, null));
		
		Console.WriteLine("- calling via delegate again");
		action = (Action)(Delegate.CreateDelegate(typeof(Action), p, method));
		action();
	}
	
	public static void Main()
	{
		Console.WriteLine("Press key to run");
		Console.ReadLine();
		
		CheckCaller();
		
		Person p = new Person();
		Console.WriteLine(p.SaySomething());
		Console.WriteLine(p.SaySomethingSecure());
		
		MethodInfo privateMethod = typeof(Person).GetMethod("SayInternal", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		Console.WriteLine("invoking private method via Reflection:");
		Console.WriteLine(privateMethod.Invoke(p, null));
		
		Console.WriteLine("----------------------");
		
		privateMethod = typeof(Person).GetMethod("SayInternalSecure", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		Console.WriteLine("invoking secured private method via Reflection:");
		try
		{
			Console.WriteLine(privateMethod.Invoke(p, null));
		}
		catch(Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
    }
