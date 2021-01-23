     ConsoleKeyInfo chinput = Console.ReadKey();
            
            switch (chinput.Key)
            {
                case ConsoleKey.X:
                    { 
                        Console.WriteLine("You pressed x...");
                        break;
                    }
                case ConsoleKey.Y:
                    {
                        Console.WriteLine("You pressed y..");
                        break;
                    }
                case ConsoleKey.D:
                    {
                        if (activated != true)
                        {
                            Console.WriteLine("Please activate first!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Active..");
                            break;
                        }
                    }
                case ConsoleKey.A:
                    {
                        if (activated != true)
                        {
                            activated = true;
                            Console.WriteLine("Activating..");
                            break;
                        }
                        else
                        {
                            activated = false;
                            Console.WriteLine("Deactivating.");
                            break;
                        }
                    }
                default:
                    Console.WriteLine("Unknown Command.");
                    break;
            } 
