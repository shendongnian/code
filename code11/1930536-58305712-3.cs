     Dictionary<char, string> map = new Dictionary<char, string>() {
       {'x', "XX"}, // change x into "XX"
       {'y', ""},   // remove y
       {'z', ""},   // remove z
     };
     // Now input.Length is estimation; you may want to put, say input.Length + 1000  
     StringBuilder sb = new StringBuilder(input.Length); 
     foreach (var c in input) {
       if (map.TryGetValue(c, out var v))
         sb.Append(v);
       else 
         sb.Append(c);
     }
     input = sb.ToString();
