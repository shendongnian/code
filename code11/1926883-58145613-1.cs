    static public int GetDecimalDigit(this decimal value, int position)
    {
      if ( position <= 0 )
        throw new ArgumentOutOfRangeException();
      char separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
      var list = value.ToString().Split(separator);
      if ( list.Length != 2 )
        throw new ArgumentOutOfRangeException();
      position--;
      if ( position > list[1].Length )
        throw new ArgumentOutOfRangeException();
      return int.Parse(list[1].Substring(position, 1));
    }
    static void Main(string[] args)
    {
      var value = 0.26579m;
      int digitDecimal = value.GetDecimalDigit(3);
      Console.WriteLine(digitDecimal);
      Console.ReadKey();
    }
