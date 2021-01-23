    public static string double2string( double value , int integerDigits , int fractionalDigits )
    {
      string        decimalPoint = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator ;
      StringBuilder sb           = new StringBuilder() ;
      sb.Append('0',integerDigits)
        .Append(decimalPoint)
        .Append('0',fractionalDigits)
        ;
      return value.ToString( sb.ToString() ) ;
    }
