    static void DrawMap(char[,] map)
    {
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Console.Write(map[x, y] + " ");
            }
            Console.WriteLine();
        }
    }
