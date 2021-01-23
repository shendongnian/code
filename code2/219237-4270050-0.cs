    public static void PrintNumbers(int current, int index)
    {
     Console.Write(current + ", ");
     
     PrintNumbers(current + index, index + 1);
    }
    
    PrintNumbers(1, 0);
