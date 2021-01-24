    using System.Collections.Generic;
    class Startup
    {
      static void Main()
      {
        int entry = 1233;
        var test = Enumerable.Range(0,entry)
          .Select(i=> {
            var y = new List<Info>();
            if(i%3==0)
            {
              y.Add(new Info {
                capacity = i*2;
                name = i.ToString();
              });
            }
            if(i%5==0)
            {
              y.Add(new Info {
                capacity = i*2;
                name = i.ToString() + i.ToString();
              });
            }
            return y;
          }).ToArray();
        }
    
        struct Info
        {
            public int capacity;
            public string name;
        }
    }
