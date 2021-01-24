    public static int GetStuff(string title)
    {
       var value = 0;
       Console.WriteLine($"{title}: ");
       while(!int.TryParse(Console.ReadLine(), out value))
          Console.WriteLine($"You had one job! {title}: ");
       return value;
    }
    
    
