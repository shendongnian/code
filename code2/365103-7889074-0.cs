    public static string Replace(this string str, string oldValue, Func<string> newValueFunc)
        {
          return Regex.Unescape( Regex.Replace( Regex.Escape(str),
                                                Regex.Escape(oldValue),
                                                match => newValueFunc() ) );
        }
