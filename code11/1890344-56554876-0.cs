    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Foo foo = new Foo();
            foo.PrintMessage1();
    		foo.PrintMessage2();
    		foo.PrintMessage3();
    	}
    }
    
    public partial class Foo
    {
    	public void PrintMessage1()
        {
            Console.WriteLine("Foo1");
        }  
    }
    
    public partial class Foo
    {
        public void PrintMessage2()
        {
            Console.WriteLine("Foo2");
        }
    }
    
    public partial class Foo
    {
        public void PrintMessage3()
        {
            Console.WriteLine("Foo3");
        }
    }
