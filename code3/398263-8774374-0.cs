        void Main()
        {
        	Test test = new Test();
        	test.CallMe();
        }
        
        
        public class Test {
        
        	List<string> _names= new List<string>(); 
        	
        	public List<string> Names {
        		get {
        		Console.WriteLine("Lock");
        		lock(_names) {
        			Console.WriteLine("Exit");
        		 	return _names;
        		}
        			
        		}		
        		
        	}
        	
        	public void CallMe()
        	{
        		foreach(String s in Names)
        		{
        			Console.WriteLine(s);
        		}
        	}
     }
