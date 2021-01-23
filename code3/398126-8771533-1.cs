    public class checkmax
        {
    
            static int Max(int[] p)
            {
                int max = p[0];
                for (int i = 1; i < p.GetLength(0); i++)
                {
                    if (p[i] > max) max = p[i];
                }
                return max;
            }
        
        
            static void Main(string[] args)
            {
                int[] p = new int[10];
                for (int i = 0; i < p.GetLength(0); i++)
                {
                    Console.Write("Vpiši {0}. celo število: ", i);
                    p[i] = int.Parse(Console.ReadLine());
                }
                int max = Max(p);
                Console.WriteLine(max);
                Console.ReadKey(true);
            }
        }
    }
