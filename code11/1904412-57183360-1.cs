         var strings = new List<string>(){/* whatever strings */};
         var typeTesters = new List<Func<string, bool>>
         {
             text => int.TryParse(text, out _),
             text => double.TryParse(text, out _),
             text => long.TryParse(text, out _),
         };
         for (var index = 0; index < 4; index++)
         {
             var str = strings[index];
             var tester = typeTesters[index];
             // Attempt something like this
             if (!tester(str))
                 throw new Exception();
         }
