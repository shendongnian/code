           string s = @"111,222,""33,44,55"",666,""77,88"",""99""";
           List<string> result = new List<string>();
           var splitted = s.Split('"').ToList<string>();
           splitted.RemoveAll(x => x == ",");
           foreach (var it in splitted)
           {
               if (it.StartsWith(",") || it.EndsWith(","))
               {
                   var tmp = it.TrimEnd(',').TrimStart(',');
                   result.AddRange(tmp.Split(','));
               }
               else
               {
                   if(!string.IsNullOrEmpty(it)) result.Add(it);
               }
          }
           //Results:
           foreach (var it in result)
           {
               Console.WriteLine(it);
           }
