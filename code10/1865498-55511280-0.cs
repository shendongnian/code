    public static class FooQueryExtensions
    {
       public static IQueryable<FooResult> MyFooQuery(this IQueryable<Foo> source)
       {
          return source.SelectMany(...).Where(...); //basicly do what yuo want
       }
    }
