       void method1()
        {
           for (var i = 0; i < 100; i++)
           {
               method2(i);
               Console.WriteLine(i);
        
                EndOfLoop: //This is something like a setjmp marker
                        ;
             }
        }
        
        void method2()
        {
           if (i%10 == 0)
               Console.WriteLine("Next Number can be divided by 10");
        
       // Now Long jmp to EndOfLoop
        #if IL
            br EndOfLoop 
        #endif
        }
