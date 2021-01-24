    public static int Persistence(int number)
    {
        if (number < 10)
            return number;
        int result = 1;
        foreach (string num in number.ToString().ToCharArray().Select(x => x.ToString()))
            result *= int.Parse(num);
        return Persistence(result);
    }
