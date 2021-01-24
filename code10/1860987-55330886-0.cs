    public int GetUserAnswer()
    {
       Console.Write("Enter a number");
       if(int.TryParse(Console.ReadLine(), out int number))
         return number;
       return -1;
    }
