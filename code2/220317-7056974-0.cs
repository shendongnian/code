        static int[] a = new int[40];
        static Random r = new Random();
        static bool b;
        static void Main(string[] args)
        {
            int t;
            for (int i = 0; i < 20; i++)
            {
            lab:  t = r.Next(1, 40);
                for(int j=0;j<20;j++)
                {
                    if (a[j] == t)
                    {
                        goto lab;
                    }
                }
                
                a[i] = t;
                Console.WriteLine(a[i]);
            }
            Console.Read();
        }
    }
