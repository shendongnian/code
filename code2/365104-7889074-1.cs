    public static string Replace(this string str, string oldValue, Func<string> newValueFunc)
    {
      return Regex.Replace( str,
                            Regex.Escape(oldValue),
                            match => newValueFunc() );
    } 
