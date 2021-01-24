static void Main(string[] args)
        {
            int x=3;
            int y = 15;
            int[] elemek = new int[7];
            do{
                for (int i = 0; i < 5; i++){
                    Console.Clear();
                    Console.SetCursorPosition(x, y);
                    x++;
                    Console.WriteLine("{0:██}{1:██}{2:██}", elemek[i], elemek[i + 1], elemek[i + 2]);
                    System.Threading.Thread.Sleep(100);
                    if (i >= 4){
                        for (int j = 0; j < 5; j++){
                            Console.Clear();
                            Console.SetCursorPosition(x, y);
                            x--;
                            Console.WriteLine("{0:██}{1:██}{2:██}", elemek[i], elemek[i + 1], elemek[i + 2]);
                            System.Threading.Thread.Sleep(100);
                        }
                        i = -1;
                    }
                    if (Console.KeyAvailable) break;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
            Console.WriteLine("ready");
            Console.ReadLine();
        }
