    public enum SSNGender
    {
      Female,
      Male
    }
    class Program
    {
      static public Dictionary<SSNGender, string> SSNGenderText
        = new Dictionary<SSNGender, string>()
      {
        { SSNGender.Female, "Woman" },
        { SSNGender.Male, "Man" },
      };
      static public SSNGender CheckSSNGender(string pnr)
      {
        // Here check the validity of the pnr (length, format...)
        return pnr[9] % 2 == 0 ? SSNGender.Female : SSNGender.Male;
      }
      static void Main(string[] args)
      {
        Console.WriteLine("Write a personnr in the format yymmdd-nnnn: ");
        string nr = Console.ReadLine();
        var result = CheckSSNGender(nr);
        Console.WriteLine(SSNGenderText[result]);
        Console.ReadKey();
      }
