    long lTicks;
                char[] tmpChar = { 'a', 'b', 'c', 'd', 'e' };
                String tmpString = "abcde";
                char chRead;
    
                lTicks = DateTime.Now.Ticks;
                for (int i = 0; i < 100000000; i++)
                    chRead = tmpChar[i%5];
    
                Console.WriteLine(((DateTime.Now.Ticks - lTicks) / 10000).ToString());
    
                lTicks = DateTime.Now.Ticks;
                for (int i = 0; i < 100000000; i++)
                    chRead = tmpChar[i % 5];
    
                Console.WriteLine(((DateTime.Now.Ticks - lTicks) / 10000).ToString());
    
                lTicks = DateTime.Now.Ticks;
                for (int i = 0; i < 100000000; i++)
                    chRead = tmpString[i%5];
    
                Console.WriteLine(((DateTime.Now.Ticks - lTicks) / 10000).ToString());
    
                lTicks = DateTime.Now.Ticks;
                for (int i = 0; i < 100000000; i++)
                    chRead = tmpString[i % 5];
    
                Console.WriteLine(((DateTime.Now.Ticks - lTicks) / 10000).ToString());
    
                Console.ReadLine();
