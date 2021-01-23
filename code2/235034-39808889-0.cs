       static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                string []a = Console.ReadLine().Split();
                string[] b = Console.ReadLine().Split();
                int n = int.Parse(a[0]);
                int k = int.Parse(a[1]);
                int c = int.MinValue;
                for (int l = 0; k<=n; l++)
                {
                    for (int j = l; j < k; j++)
                    {
                        if (int.Parse(b[j]) > c)
                            c = int.Parse(b[j]);
                    }
                    k++;
                    Console.Write(c);
                    c = int.MinValue;
                }
            }
