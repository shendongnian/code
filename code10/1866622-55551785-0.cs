    public static void SeparateRandomNumbers()
    {
        IList<int> positive_numbers = new List<int>();
        IList<int> negative_numbers = new List<int>();
        Random objeto = new Random();    
        for (int i = 0; i < 50; i++)
        {           
           var number = objeto.Next(-50, 50);    
           if (isNegtive(number))
           {
              negative_numbers.Add(number);
           }
           else
           {
              positive_numbers.Add(number);
           }
        }
     }
