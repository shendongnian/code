    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	  class Case{
    		string type;
    		string status;
    		 public Case(string type_val, string status_val ){
    			  status = status_val;
    			 type = type_val;
    		 }
    		 
    		public override int GetHashCode()  
            {  
                return type.GetHashCode()+status.GetHashCode();  
            }  
            public override bool Equals(object obj)  
            {  
                Case test = obj as Case;  
                if (test== null)  
                    return false;  
                return type == test.type &&  status == test.status ;  
            } 
    		
    	}
    	public static void Main()
    	{
    		bool checkStatus = true;
    		HashSet<Case> vaild_cases = new HashSet<Case>();
    		vaild_cases.Add(new Case("A","Complete"));
    		vaild_cases.Add(new Case("B","Complete"));
    		vaild_cases.Add(new Case("B","Other status"));
    		vaild_cases.Add(new Case("B","someother status"));
    		Case current_case = new Case("A","Complete");
    		if (!checkStatus || vaild_cases.Contains(current_case))
    			UpdateData();
    	}
    
    	static void UpdateData()
    	{
    		Console.WriteLine("Hello, World!");
    		return;
    	}
    }  
