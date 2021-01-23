    public static void ValidateIdentifier()
    {
      Regex regex = new Regex(
      @"^@?_*[\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]*$");
      bool isMatch1 = regex.IsMatch("@_Bling"); //true
      bool isMatch2 = regex.IsMatch("__Bling"); //true
      bool isMatch3 = regex.IsMatch("_@Bling"); //false
    }
