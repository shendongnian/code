    using System;
    using Prism.Commands;
    
    namespace TestWpfApplication
    {
    	internal class Student
    	{
    		DelegateCommand selectCommand;
    
    		public string Type => "Student";
    
    		public string FullName => "My name is student";
    
    		public DelegateCommand SelectCommand
    		{
    			get => selectCommand ?? (selectCommand = new DelegateCommand(Select, CanSelect));
    		}
    
    		public bool CanSelect()
    		{
    			return false;
    		}
    
    		public void Select()
    		{
    			Console.WriteLine("Student Clicked");
    		}
    	}
    }
