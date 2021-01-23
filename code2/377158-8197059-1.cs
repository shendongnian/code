     [Web Method]
     public List<Foo> GetFoos()
     {
          var foos = Cache["FooList"] as List<Foo>;
          if (foos == null)
          {
              ... get foos from remote web service ...
              Cache.Insert( "FooList", foos, null, DateTime.Today.AddDays(1), Cache.NoSlidingExpiration );
          }
          return foos;
     }
