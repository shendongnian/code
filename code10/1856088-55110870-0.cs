    using System;
    using System.Collections;
    namespace SortJaggedArray
    {
        class host
        {
            [STAThread]
            static void Main(string[] args)
            {
                int[,][] arr = new int[2,3][];
                arr[0,0] = new int[3] { 1, 5, 3 };
                arr[0,1] = new int[4] { 4, 2, 8, 6 };
                arr[0,2] = new int[2] { 2, 8 };
                arr[1,0] = new int[2] { 7, 5 };
                arr[1,1] = new int[5] { 8, 7, 5, 9, 2 };
                arr[1,2] = new int[2] { 1, 4};
                // Write out a header for the output.
                Console.WriteLine("Array - Unsorted\n");
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    Console.WriteLine($"Nr {i}:");
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        for (int k = 0; k < arr[i,j].Length; k++)
                        {
                            Console.Write($"{arr[i,j][k]} ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
    }
    //Output:
    //Nr 0:
    //1 5 3
    //4 2 8 6
    //2 8
    //Nr 1:
    //7 5
    //8 7 5 9 2
    //1 4
