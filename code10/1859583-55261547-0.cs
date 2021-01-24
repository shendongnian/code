      public static bool IsValidDouble(this string s)
      {
          double d = 0;
          double.TryParse(s, out d);
          return d != 0; //will be false if result is 0 
          //return d > 0; if you don't want negativer values 
      }
