    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using StackOverflow.MyExtensions;
    
    namespace StackOverflow
    {
    
    
    	class Person
    	{
    		string _FirstName; // FirstName
    
    		public string FirstName
    		{
    			get { return _FirstName; }
    			set { _FirstName = value; }
    		}
    
    		public string LastName;
    
    	}
    
    
    	class Program
    	{
    
    		static void Main(string[] args)
    		{
    
    			Person SamplePerson = new Person();
    
    			if (SamplePerson.PropertyExists("FirstName"))
    				Console.WriteLine("Yes! Property does exist!");
    			else
    				Console.WriteLine("Nope, property does not exist on object SamplePerson");
    
    			if (SamplePerson.PropertyExists("LastName"))
    				Console.WriteLine("Yes! Property does exist!");
    			else
    				Console.WriteLine("Nope, property does not exist on object SamplePerson");
    
    		}
    	}
    
    }
