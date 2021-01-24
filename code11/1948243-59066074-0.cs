    namespace ConsoleApp1
    {
        class Methods
        {
            public int _first, _second, _third, _fourth, _fifth;
    
            static void Main(string[] args)
            {
                for (int i=1;i<=5;i++)
                {
                    Console.WriteLine("Enter {0}st number:", i);
                    Console.ReadLine();
                    switch (i)
                    {
                        case 1:
                            _first = i;
                            break;
                    }
                }
            }
        }
    }
