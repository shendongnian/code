    public static string Generate(int size, params Options[] options)
       => string.Concat(Enumerable.Repeat(0,size).Select(x => GetChar(options)));
    
    private static char GetChar(params Options[] options)
    {
       switch (Rand.Get(options))
       {
          case Options.Upper:  return char.ToUpper(Rand.Get(Letters.ToCharArray())); ;
          case Options.Lower: return Rand.Get(Letters.ToCharArray()); 
          case Options.Numbers:  return Rand.Get(Numbers.ToCharArray()); 
          case Options.Symbols:  return Rand.Get(Symbols.ToCharArray());
          default: throw new ArgumentOutOfRangeException();
       }
    }
