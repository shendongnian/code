     string source = "Abracadba";
     StringBuilder sb = new StringBuilder(source.Length);
     for (int i = 0; i < source.Length; ++i) {
       sb.Append(i % 2 != 0
         ? char.ToUpper(source[i]) 
         : char.ToLower(source[i]));
     }
     string result = sb.ToString();
