     int value = 24;
     bool firstTime = true; 
     // Simplest, not that efficient
     for (int i = 1; i <= value; ++i) {
       if (value % i == 0) {
         // print "and" before printing i
         if (!firstTime)         
           Console.Write(" and ");
         firstTime = false;   
         Console.Write(i);
       }
     }
