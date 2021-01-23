    class Program
          {
            static void Main(string[] args)
            {
              var cat = new Cat();
              cat
                .ToFeed(1, LikeMilk, c.Inc)
                .ToFeed(2, LikeMilk, c.Inc);
            }
        
            private static bool LikeMilk(int liters)
            {
              return liters < 1;
            }
          }
        
          public class Cat
          {
            private int Weith { get; set; }
        
            public void Inc()
            {
              Weith++;
            }
        
            public Cat ToFeed(int liters, Func<int, bool> predicate, Action<Cat> action)
            {
              if (predicate(liters))
                action(this);
              return this;
            }
          }
        }
