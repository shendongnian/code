    if (result is object[,] arr)
    {    
        for (i = 0; i < arr.GetLength(0); i++)
        {
            for (j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j]);
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
