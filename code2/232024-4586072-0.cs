    static void Main(string[] args)
            {
                Console.WriteLine("enter s1 :");
                string s1 = Console.ReadLine();
                Console.WriteLine("enter s2 :");
                string s2 = Console.ReadLine();
    
                Console.WriteLine("first dif index  :{0}", findFirstDifIndex(s1, s2));
            }
    
            private static int findFirstDifIndex(string s1, string s2)
            {
                for (int i = 1; i <= s1.Length; i++)
                    if (s1[i] != s2[i]) return i;
    
                return -1;//the are the same
            }
