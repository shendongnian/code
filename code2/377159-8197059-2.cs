     [Web Method]
     public List<Foo> GetFoos()
     {
          var foos = Cache["FooList"] as List<Foo>;
          if (foos == null)
          {
              ... get foos from remote web service ...
              var expiration = DateTime.Today.AddHours(7);
              if (DateTime.Now >= expiration)
              {
                  expiration = expiration.AddDays(1);
              }
              Cache.Insert( "FooList", foos, null, expiration, Cache.NoSlidingExpiration );
          }
          return foos;
     }
