    abstract class A
    {
       protected static int counter;
    }
    
    class A<T> : A
    {
       private static int Counter {
    	   get { 
    		  Increment(); 
    		  return counter; 
    	   }
       }
    
       private static void Increment() {
    	   counter++; 
       }
    
       public int Index; 
    
       public A()
       {
    	   this.Index = Counter;
    
    	   Console.WriteLine(this.Index);      
       }
    }
