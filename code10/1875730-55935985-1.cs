    Console.Write("Input number : ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("The Formula : ");
    
                int accommodate = 0;
    
                for (int i = num; i > 0; accommodate = i /= 2)
                {
                    if (accommodate % 2 == 0)
                    {
    
                        Console.WriteLine(i + "/2 = 0");
                    }
                    else
                    {
                        Console.WriteLine(i + "/2 = 1");
                    }
                }
                Console.ReadKey();
