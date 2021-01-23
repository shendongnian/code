    public static void PrintFigure(int shapeSize)
    {
        string figure = "\\/";
        for (int loopTwo = 1; loopTwo <= shapeSize - 1; loopTwo++)
        {
            Console.Write($"{figure}");
        }
    }
