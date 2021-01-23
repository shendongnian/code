     public static string ToDataString(this string prm)
       {
           if (prm == null)
           {
               return "NULL";
           }
           else
           {
               return "'" + prm.Replace("'", "''") + "'";
           }
       }
