    int[,] image = new int[16 , 16];
    int current = 0;
    for (int x = 15; x >= 0; x--)
    {
        for (int y = 0; y < 16; y++)
        {
            image[x, y] = current;
            current++;
        }
    }
    // Output
    for (int y = 0; y < 16; y++)
    {
        for (int x = 0; x < 16; x++)
        {
            Console.Write(image[x,y] + ", ");
        }
        Console.WriteLine();
    }
