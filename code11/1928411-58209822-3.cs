    static void Test()
    {
      string str1 = null;
      string str2 = "";
      string str3 = "TEST";
      string str4 = "TEST STRING,  FOR STACK OVERFLOW!";
      Console.WriteLine(str1.CapitalizeWords());
      Console.WriteLine(str2.CapitalizeWords());
      Console.WriteLine(str3.CapitalizeWords());
      Console.WriteLine(str4.CapitalizeWords());
    }
