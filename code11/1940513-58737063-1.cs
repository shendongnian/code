       int[,] array1 = new int[6, 6]
            {
                {10, 20, 10, 20, 21, 99 },
                {2, 27, 5, 45, 20, 13 },
                {17, 20, 20, 33, 33, 20 },
                {21, 35, 15, 54, 20, 37 },
                {31, 101, 25, 55, 26, 66 },
                {45, 20, 44, 12, 55, 98 }
            };
    
            int Length = array1.GetLength(0);
            int Height = array1.GetLength(1);
            Console.WriteLine("  Col 0  Col 1  Col 2  Col 3  Col 4  Col 5");
            for (int i = 0; i < Length; i++)
            {
                Console.Write("Row {0} ", i); // Outside of the loop :)
                for (int j = 0; j < Height; j++)
                {
                    Console.Write(string.Format("{0,6} ", array1[i, j]));
                }
                Console.Write("\n" + "\n");
            }
    
            Console.ReadKey();
