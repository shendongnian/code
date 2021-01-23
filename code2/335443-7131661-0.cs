    static void Main(string[] args)
    {
        foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            try
            {
                DateTime.Parse("5/26/2011", ci);
                Console.WriteLine(String.Format("Able to parse with {0} CultureInfo object.", ci));
            }
            catch
            {
                Console.WriteLine(String.Format("Unable to parse with {0} CultureInfo object.", ci));
            }
        }
        Console.ReadLine();
    }
