    public class MyMethods
    {
       public void Method1()
       {
         // defining your methods 
    	 
         Action method1 = new Action( () => 
    	  { 
    	     Console.WriteLine("I am method 1");
    		 Thread.Sleep(100);
    		 var b = 3.14;
    		 Console.WriteLine(b);
    	  }
    	 ); 
    
         Action<int> method2 = new Action<int>( a => 
    	  { 
    	     Console.WriteLine("I am method 2");
    		 Console.WriteLine(a);
    	  }
    	 ); 
    
    	 Func<int, bool> method3 = new Func<int, bool>( a => 
    	  { 
    	     Console.WriteLine("I am a function");
    		 return a > 10;
    	  }
    	 ); 
    
    	 
    	 // calling your methods
    
    	 method1.Invoke();
    	 method2.Invoke(10);
    	 method3.Invoke(5);
    	
       }
    }
