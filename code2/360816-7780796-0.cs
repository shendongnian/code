    var Input = "{1, 2, 3, 4, 5, 6, 7} foo {1, 2, 3} baa {1, 2, 3, 4} abc";
    var Pattern = "\\{([0-9, ]+)\\}";
    var Matches = Regex.Matches(Input, Pattern, RegexOptions.IgnorePatternWhitespace);
    foreach (Match match in Matches)
    {
        string s = match.Groups[1].Value; // n1,n2,n3.. 
         //do actions here 
        /* 
         * if you need parse each element,use s.Split(',').
         * For example 
         *      s is '1,2,3' 
         *      string[] parts = s.Split(',');
         *      for(int x = 0,max = parts.Length; x < max; x++) {
         *          Console.WriteLine(parts[x]);
         *      }
         *      
         *      the output is something like:
         *      1
         *      2
         *      3
         */
      
    }
