       private static void LoopMethod()
            {
                foreach (string str in jack)
                {
                    if (i == 4)
                        LoopMethod();
    
                    Console.WriteLine(str);
                    i++;
                }
            }
