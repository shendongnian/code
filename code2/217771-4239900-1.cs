    string[] source = {"A", "A.B", "A.B.D", "B.C", "B.C.D", "B.D", "E", "F", "F.E"};
    var result = 
    source.Distinct()
          .Select(str => str.Split('.'))
          .GroupBy(arr => arr[0])
          .Select(g =>
            {
              return string.Join(".", 
                     g.Aggregate((arr1, arr2) =>
                        {
                          return arr1.TakeWhile((str, index) => index < arr2.Length 
                                                   && str.Equals(arr2[index]))
                                     .ToArray();
                        }));
            });
