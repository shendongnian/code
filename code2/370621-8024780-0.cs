     public static int[] Get(System.Random r)
        {
            int[] a = new int[6];
            bool flag;
            int val;
            for (int i = 0; i < a.Length; ++i)
            {
                flag = false;
                do
                {
                    val = r.Next(1, 50);
                    for (int k = 0; k < i; ++k)
                        if (a[k] == a[i])
                        {
                            flag = true;
                            break;
                        }
                    a[i] = val;
                } while (flag);
            }
            return a;
        }
        public static void Main()
        {
            int[] a;
            System.Random r = new System.Random();
            for (int i = 0; i < 10; ++i)
            {
                a = Get(r);
                foreach (int x in a)
                    Console.Write("{0} ", x);
                Console.WriteLine();
            }
        }
