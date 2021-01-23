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
    
          Action method2 = new Action( () => 
    	  { 
    	     Console.WriteLine("I am method 2");
    		 Console.ReadKey();
    	  }
    	 ); 
    	 
    	 // calling your methods
    
    	 method1.Invoke();
    	 method2.Invoke();
    	
       }
    }
