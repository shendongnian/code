     int [] Number = new int[args.Length -1];
            for (int i = 0; i < args.Length - 1; i++) {
                int num;
                int.TryParse(args[i + 1], out num);
                Number[i] = num;
            }
            int result;
            int.TryParse(args[1], out result);
                switch (args[0])
                {
                    case "+":
                       
                        for (int i = 1; i < Number.Length; i++)
                        {
                           result = result - Number[i];
                        }
                        Console.WriteLine(result);
                        break;
                    case "-":
                        
                        for (int i = 1; i < Number.Length; i++)
                        {
                           result = result - Number[i];
                        }
                        Console.WriteLine(result);
                        break;
                    case "*":
                     
                        for (int i = 1; i < Number.Length; i++)
                        {
                           result = result * Number[i];
                        }
                        Console.WriteLine(result);
                        break;
                      
                    case "/":
                        
                        for (int i = 1; i < Number.Length; i++)
                        {
                           result = result - Number[i];
                        }
                        Console.WriteLine(result);
                        break;
                        
                    default:
                        Console.WriteLine("Invalid code");
                        break;
                }
                Console.ReadKey();
        }
