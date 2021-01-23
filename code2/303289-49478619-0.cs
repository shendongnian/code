    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace _3_x_3_Matrix_multiplier
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[,,] matrix = new int[3, 3, 3];
                for (int z = 0; z < 2; z++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            Console.WriteLine("element: {0} , {1}", x, y);
                            matrix[x, y, z] = int.Parse(Console.ReadLine());
                        }
                    }
                }
                for (int xm = 0; xm < 3; xm++)
                {
                    for (int ym = 0; ym < 3; ym++)
                    {
                        for (int zm = 0; zm < 3; zm++)
                        {
                            matrix[xm, ym, 2] += (matrix[0 + zm, ym, 0] * matrix[xm, 0 + zm, 1]);
                        }
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("\n");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(matrix[j, i, 2] + " ");
                    }
                }
                Console.ReadLine();
            }
        }
    }
