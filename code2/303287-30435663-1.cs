    namespace matrix_multiplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i, j;
                int[,] a = new int[2, 2];
                Console.WriteLine("Enter no for 2*2 matrix");
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < 2; j++)
                    {
                        a[i, j] = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine("First matrix is:");
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < 2; j++)
                    {
                      Console.Write(a[i,j]+"\t");
                    }
                    Console.WriteLine(); 
                }
    
               
                int[,] b = new int[2, 2];
                Console.WriteLine("Enter no for 2*2 matrix");
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < 2; j++)
                    {
                        b[i, j] = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine("second matrix is:");
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < 2; j++)
                    {
                        Console.Write(b[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
    
                Console.WriteLine("Matrix multiplication is:");
                int[,] c = new int[2, 2];
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < 2; j++)
                    {
                         
                         
                        c[i,j]=0;
                         for (int k = 0; k < 2; k++)
                         {
                             c[i, j] +=  a[i, k] * b[k, j];
                         }
                     }
                }
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < 2; j++)
                    {
                        Console.Write(c[i, j]+"\t");
                    }
                    Console.WriteLine();
                }
    
                Console.ReadKey();
            }
        }
    }
