    using System.Collections.Generic;
    using System.Linq; // <- Don't forget this
    					
    public class Program
    {
    	public class ClassA {
    		public int A {get; set;}
    	}
    	public class ClassB {
    		public int B {get; set;}
    	}
    	public class ClassC {
    		public int C {get; set;}
    	}
    	
    	public class MyModel
    	{
    		public int id {get;set;}
    		public List<ClassC> classc {get; set;}
    		public Dictionary<ClassA,ClassB> dic {get; set;}
    	}
    	
    	public class NewMyModel
    	{
    		public int id {get;set;}
    		public List<ClassC> classc {get;set;}
    		public List<ClassB> listb {get; set;}
    	}
    
    	public static void Main()
    	{
    		// Initializing MyModel
    		MyModel a = new MyModel(){
    			id = 1,
    			classc = new List<ClassC>(){
    				new ClassC(){
    					C = 1
    				}
    			},
    			dic = new Dictionary<ClassA,ClassB>(){
    				{
    					new ClassA(){
    						A = 1
    					},
    					new ClassB() {
    						B = 1
    					}
    				}
    			}
    		};
    		
    		NewMyModel b = new NewMyModel() {
    			id = a.id,
    			classc = a.classc,
    			// Converting values of the dictionary to list
    			// Note: Values contains ClassB type of objects
    			listb = a.dic.Values.ToList()
    		};
    	}
    }
