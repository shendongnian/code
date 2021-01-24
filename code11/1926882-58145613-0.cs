    static public int GetDecimalDigit(this decimal num, int pos)
    {
      char separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
      var list = num.ToString().Split(separator);
      if ( list.Length != 2 )
        throw new ArgumentOutOfRangeException();
      pos--;
      if ( pos > list[1].Length )
        throw new ArgumentOutOfRangeException();
      return int.Parse(list[1].Substring(pos, 1));
    }
    static void Main(string[] args)
    {
      var value = 0.26579m;
      Console.WriteLine(value.GetDecimalDigit(3));
      Console.ReadKey();
    }
