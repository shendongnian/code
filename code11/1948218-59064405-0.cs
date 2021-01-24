    using System;
    
    class MainClass {
      public static void Main (string[] args) {
    	  String str = "This is example 1, this is example 2, that is example 3.";
    	  while(str.Contains("is") ) {
    		str.Replace("is", "###")
    	    Console.WriteLine (str);
    	  }
      }
    }
