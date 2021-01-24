     var inputs = new[]
     {
         "かたむく；かたぶく[ok]",
         "そば[側,傍]；そく[側]；はた",
         "くすり",
         "おととい[gikun]；おとつい[gikun]；いっさくじつ"
     };
     var separators = new[] {' ', '['};
     foreach (var input in inputs)
     {
         var separatorPosition = input.IndexOfAny(separators);
         if (separatorPosition >= 0)
         {
             Debug.WriteLine($"Split: {input.Substring(0, separatorPosition)}");
         }
         else
         {
             Debug.WriteLine($"No Split: {input}");
         }
     }
