    using System;
    using Prism.Commands;
    
    namespace TestWpfApplication
    {
    	internal class Person
    	{
    		DelegateCommand selectCommand;
    
    		public string Type => "Person";
    
    		public string FullName => "My name is person";
    
    		public DelegateCommand SelectCommand
    		{
    			get => selectCommand ?? (selectCommand = new DelegateCommand(Select, CanSelect));
    		}
    		public bool CanSelect()
    		{
    			return true;
    		}
    
    		public void Select()
    		{
    			Console.WriteLine("Person Clicked");
    		}
    	}
    }
