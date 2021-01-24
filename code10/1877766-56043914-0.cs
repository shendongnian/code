    public static void Main(String[] args)
    {
        string s1;
        DateTime dat = new DateTime(1970,01,01);
        Console.WriteLine("Enter the input value");
        s1=Console.ReadLine();
        CultureInfo culture = new CultureInfo("te-IN");
        DateTime temp = Convert.ToDateTime(s1, culture);
        Console.WriteLine("The input date is "+temp.ToString());
        double x = (dat-temp).TotalMilliseconds;
        Console.WriteLine("Milli-Seconds that have passed since January 1, 1970 is "+x);
        Console.ReadLine();
    }
