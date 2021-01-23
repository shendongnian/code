        public static void Main(string[] args)
            {
                int[] numbers = new int[10];
    
                Console.Write("index ");
    
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = i;
    
                    Console.Write(numbers[i] + " ");
    
                }
    
                Console.WriteLine("");
    
                Console.WriteLine("");
                        
                Console.Write("value ");
                
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = numbers.Length - i;
    
                    Console.Write(numbers[i] + " ");
    
                }
    
                Console.ReadKey();
            }
        }
    }
