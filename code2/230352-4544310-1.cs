    using System;
    using System.Text;
    
    namespace Program {
       class Demo {
          static string[] extensions = 
          //    0     1     2     3     4     5     6     7     8     9
             { "th", "st", "nd", "rd", "th", "th", "th", "tn", "th", "th",
          //    10    11    12    13    14    15    16    17    18    19
               "th", "th", "th", "th", "th", "th", "th", "tn", "th", "th",
          //    20    21    22    23    24    25    26    27    28    29
               "th", "st", "nd", "rd", "th", "th", "th", "tn", "th", "th",
          //    30    31
               "th", "st" };
          
          public static void Main() {
             String strTestDate = "02-11-2007";
             DateTime coverdate = DateTime.ParseExact(strTestDate, "dd-MM-yyyy", null);
             string s = coverdate.ToString(" MMMM yyyy");
             string t = string.Format("{0}{1}",coverdate.Day,extensions[coverdate.Day]);
             string result = t + s;
          }
       }
    }
