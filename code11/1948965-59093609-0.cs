    using System;
    
    public static class Program
    {
        public static void Main(string[] args)
        {
            var child = new Child();
            
    		PrintNatural(child);
    		Console.WriteLine();
    		
    		PrintAsINamedObject(child);
    		Console.WriteLine();
    		
    		PrintAsINamedAndAgedObject(child);
            Console.WriteLine();
    		
    		PrintAsBoth(child);
            Console.WriteLine();
    		
    		Console.ReadLine();
        }
    	
    	private static void PrintNatural(Child someChild) {
    		Console.WriteLine("Natural Name: " + someChild.Name);
    		Console.WriteLine("Natural Age: " + someChild.Age);
    	}
    	
    	private static void PrintAsINamedObject(INamedObject someChild) {
    		Console.WriteLine("Name as INamedObject: " + someChild.Name);
    	}
    	
        private static void PrintAsINamedAndAgedObject(INamedAndAgedObject someChild) {
    		Console.WriteLine("Name as INamedAndAgedObject: " + someChild.Name);
    		Console.WriteLine("Age as INamedAndAgedObject: " + someChild.Age);
    	}
    	
    	private static void PrintAsBoth<T>(T instance) where T: INamedObject, INamedAndAgedObject
    	{
    		//Console.WriteLine("Name as Generic: " + instance.Name); does not compile Name is ambiguous to the compiler
    		Console.WriteLine("Name as Generic<INamedObject>: " + ((INamedObject)instance).Name);
    		Console.WriteLine("Name as Generic<INamedAndAgedObject>: " + ((INamedAndAgedObject)instance).Name);
    		Console.WriteLine("Age as Generic: " + instance.Age);
    	}
    }
    
    interface INamedObject
    {
        string Name { get; }
    }
    
    interface INamedAndAgedObject
    {
       string Name { get; }
       int Age { get; }
    }
    
    internal class Base : INamedObject
    {
        string INamedObject.Name => "Base Name";
    }
    
    internal class Child : Base, INamedObject, INamedAndAgedObject
    {
       public string Name => "Child Name";
       public int Age => 1024;
       
       string INamedObject.Name => "Child Name Explicit (INamedObject)";
       
       string INamedAndAgedObject.Name => "Child Name Explicit (INamedAndAgedObject)";
       int INamedAndAgedObject.Age => 2048;
    }
