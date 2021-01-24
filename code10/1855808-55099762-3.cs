    public class A : IBaseInterface<A>
    {
       public A() { }
      
       public async Task<List<A>> Handler(List<A> items)
       {
          var newList= new List<A>();
          foreach (var item in items)
          {
              newList.Add(new A
              {
                  ID = item.ID,
                  Name = item.Status,
                  Retrieved = DateTime,
              });
          }
        // ...
        }
    }
