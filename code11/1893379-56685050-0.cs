    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string json = @"[
    							{ 'Product': 'P1', 'Package': 
    							   [
    								{ 'p_make': 'hy', 'p_maketype': '1', 'p_relation': 'P111'},
    								{ 'p_make': 'hz', 'p_maketype': '1', 'p_relation': 'P111' }
    					          ]
    							},
    							{ 'Product': 'P2', 'Package': 
    								 [
    								 	{ 'p_make': 'ha', 'p_maketype': '2', 'p_relation': 'P112'},
    									{ 'p_make': 'hb', 'p_maketype': '2', 'p_relation': 'P112'}
     								]
    							 }
    							]";
    
    
    		List<MyClass> myList = JsonConvert.DeserializeObject<List<MyClass>>(json);
    		// do your inserts however you do it ADO, entitiy framework etc.
    		
    	}
    }
    public class MyClass
    {
        public string Product { get; set; }
        public List<Package> Packages {get; set;}
    }
    
    public class Package
    {
    	 public string P_make { get; set; }
    	 public int P_maketype { get; set; }
    	 public string P_relation { get; set; }
    }
