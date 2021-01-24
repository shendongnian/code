    using System;
    using System.Collections.Generic;
    
    class Demo {
       static void Main() {
          string val;
          bool validEmail = false;
    
          Console.Write("Enter Email: ");
          val = Console.ReadLine();
    
          int stringSplitCount = val.Split('@').Length;
    
          if(stringSplitCount > 1 && stringSplitCount < 2) // should only have one @ symbol
            {
               stringSplitCount = val.Split('.').Length;
    
               if(stringSplitCount > 1)  // should have at least one . (dot)
                 validEmail = true
            }
    
          val += (validEmail ? " is valid" ; "is invalid");
    
          Console.WriteLine("Your input: {0}", val);
    
       }
    }
