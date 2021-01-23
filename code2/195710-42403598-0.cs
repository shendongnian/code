                double jhon = 3;
                double[] numbers = new double[3];
                for (int i = 0; i < 3; i++)
    
                {
                    numbers[i] = double.Parse(Console.ReadLine());
                
                }
                Console.WriteLine("\n");
    
                Array.Sort(numbers);
    
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(numbers[i]);
                
                }
    
                Console.ReadLine();
