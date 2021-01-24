using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // N.B. You will have to pick which order the dimensions go in.
            var ni = 4;
            var nj = 3;
            var nk = 2;
            // Make a list that could be interpreted as a 3-d array:
            var x = new List<string>();
            for (int k = 0; k < nk; k++)
            {
                for (int j = 0; j < nj; j++)
                {
                    for (int i = 0; i < ni; i++)
                    {
                        x.Add($"{k}-{j}-{i}");
                    }
                }
            }
            Console.WriteLine(string.Join(", ", x));
            // Copy the content of the list to a 3-d array:
            string[,,] array1 = new string[nk, nj, ni];
            for (int k = 0; k < nk; k++)
            {
                for (int j = 0; j < nj; j++)
                {
                    for (int i = 0; i < ni; i++)
                    {
                        var idx = i + j * (nj + 1) + k * (nk + 1) * (nj + 1);
                        array1[k, j, i] = x[idx];
                        Console.Write(array1[k, j, i] + ", ");
                    }
                }
            }
            
            Console.ReadLine();
        }
    }
}
Which outputs, for confirmation,
> 0-0-0, 0-0-1, 0-0-2, 0-0-3, 0-1-0, 0-1-1, 0-1-2, 0-1-3, 0-2-0, 0-2-1, 0-2-2, 0-2-3, 1-0-0, 1-0-1, 1-0-2, 1-0-3, 1-1-0, 1-1-1, 1-1-2, 1-1-3, 1-2-0, 1-2-1, 1-2-2, 1-2-3  
0-0-0, 0-0-1, 0-0-2, 0-0-3, 0-1-0, 0-1-1, 0-1-2, 0-1-3, 0-2-0, 0-2-1, 0-2-2, 0-2-3, 1-0-0, 1-0-1, 1-0-2, 1-0-3, 1-1-0, 1-1-1, 1-1-2, 1-1-3, 1-2-0, 1-2-1, 1-2-2, 1-2-3,
