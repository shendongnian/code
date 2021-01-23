    using System;
    
    namespace ConsoleApp
    {
    	class Example {
    		public void Run() {
    			catchy(crashA); // Calling defined functions
    			catchy(crashB);
    			catchy(()=> {
    				throw new ArgumentException("Anonymous function...");
    			});
    		}
    		void crashA() {
    			//...
    			throw new ArgumentException("another error");
    		}
    		void crashB() {
    			//...
    			throw new ArgumentException("another error");
    		}
    		void catchy(Action action) {
    			try {
    				action();
    			} catch (Exception ex) {
    				Console.WriteLine(ex);
    				// do something
    			}
    		}
    	}
    		
    	class MainClass
    	{
    		
    		public static void Main (string[] args)
    		{
    			new Example().Run();
    			Console.ReadLine();
    			Console.WriteLine ("Hello World!");
    		}
    	}
    }
    
    
