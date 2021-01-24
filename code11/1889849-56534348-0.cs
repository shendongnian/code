    static void Main()
    {
        var formats = new string[] { "dd/MM/yyyy", "d/MM/yyyy", "yyyy/MM/dd" };
        DateTime.TryParseExact("01/05/2019", formats, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime res1);
        Console.WriteLine(res1.ToLongDateString());
        DateTime.TryParseExact("1/05/2019", formats, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime res2);
        Console.WriteLine(res2.ToLongDateString());
        DateTime.TryParseExact("2019/05/01", formats, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime res3);
        Console.WriteLine(res3.ToLongDateString());
        Console.ReadLine();
    }
