    string inputNumber = "0";
    foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
    {
       try
       {
           double d = Convert.ToDouble(inputNumber, culture);
       }
       catch
       {
          Console.WriteLine(culture.Name);
       }
    }
    Console.WriteLine("end");
    Console.Read();
