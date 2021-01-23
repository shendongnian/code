    class Comparer : IEqualityComparer<string>
      {
          public bool Equals(string x, string y)
          {
              return x[0] == y[0] || x[2] == y[0];
          }
    
          public int GetHashCode(string obj)
          {
              return 0;
          }
      }
      
    var MyList = new List<String>{ 
              "A-B", 
              "B-A", 
              "C-D", 
              "C-E", 
              "D-C",
              "D-E",
              "E-C",
              "E-D",
              "F-G",
              "G-F"}.Distinct(new Comparer());
    
              foreach (var s in MyList)
              {
                  Console.WriteLine(s);
              }
