       private static void LoopMethod()
            {
               i= 0;
                foreach (string str in jack)
                {
                    if (i == 4)
                        LoopMethod();
    
                    Console.WriteLine(str);
                    i++;
                }
            }
