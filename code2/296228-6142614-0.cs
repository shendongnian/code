    static void Main()
    {
        string value = "She sells 2008 sea shells by the (foozball)";
        string foo = string.Join("", value
                                    .ToList()
                                    .Select(x => GetRand(x))
                                    );
        Console.WriteLine(foo);
        Console.Read();
    }
      
    private static string GetRand(char x)
    {             
        int asc = Convert.ToInt16(x);            
        if (asc >= 48 && asc <= 57)
        {
            //get a digit
            return  (Convert.ToInt16(Path.GetRandomFileName()[0]) % 10).ToString();       
        }
        else if ((asc >= 65 && asc <= 90)
              || (asc >= 97 && asc <= 122))
        {
            //get a char
            return Path.GetRandomFileName().FirstOrDefault(n => Convert.ToInt16(n) >= 65).ToString();
        }
        else
        { return x.ToString(); }
    }
