      public string ToPhonetic(string source)
      {
         var sb = new StringBuilder();
         foreach (var ch in source.ToUpper())
         {
            switch (ch)
            {
               case 'A':
                  sb.Append("Alpha, ");
                  break;
               case 'B':
                  sb.Append("Bravo, ");
                  break;
               default:
                  sb.Append(ch);
                  break;
            }
         }
         return sb.ToString();
      }
Fill in the missing phonetic codes and off you go.
