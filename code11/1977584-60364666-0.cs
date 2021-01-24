static void Main(string[] args)
        {
            function(2, 4);
        }
        public static void function(int n, int k)
        {
            for (int i1 = 1; i1 <= n; i1++)
            {
                
                for (int i2 = 1; i2 <= n; i2++)
                {
                    for (int i3 = 1; i3 <= k; i3++)
                    {
                        for (int i4 = 1; i4 <= k; i4++)
                        {
                            for (int i5 = 1; i5 <= n; i5++)
                            {
                                if (i5 > i1 && i5 > i2)
                                Console.Write($"{i1}{i2}{Convert.ToChar(96 + i3)}{Convert.ToChar(96 + i4)}{i5},");
                            }
                        }
                    }
                }
            }
        }
I can get answer of 
11aa2,11ab2,11ac2,11ad2,11ba2,11bb2,11bc2,11bd2,11ca2,11cb2,11cc2,11cd2,11da2,11db2,11dc2,11dd2
From ```function(2, 4);``` as you said.
Please answer :)
