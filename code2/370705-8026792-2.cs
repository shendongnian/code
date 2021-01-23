    using System;
    using System.Collections.Generic;
    
    class Program
    {
       static void Main()
       {
    	 
    	 // Create a new linked list object instance.
    	 
    	  LinkedList<string> linked = new LinkedList<string>();
    	 
    	// Use AddLast method to add elements at the end.
    	// Use AddFirst method to add element at the start.
    	
    	  linked.AddLast("cat");
    	  linked.AddLast("dog");
    	  linked.AddLast("man");
    	  linked.AddFirst("first");
    	
    	// Loop through the linked list with the foreach-loop.
    	
    	 foreach (var item in linked)
    	 {
    	    Console.WriteLine(item);
    	 }
       }
    }
    
