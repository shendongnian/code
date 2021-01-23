    int? ConvertToNumber(string value)
    {
       if (value == string.Empty) return null;
       try
       {
           var dec = decimal.Parse(value,
               NumberStyles.AllowDecimalPoint |
               NumberStyles.Number |
               NumberStyles.AllowThousands);
           return (int)Math.Round(dec);
       }
       catch (Exception ex)
       {
           Console.WriteLine("Please input a number.");
           return null;
       }
    }
