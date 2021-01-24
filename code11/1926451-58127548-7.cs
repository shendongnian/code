    public static class Extensions
    {
       public static unsafe void Mutate( this int*[] array, Func<int, int> func)
       {
          foreach (var item in array)
             *item = func(*item);
       }
    }
    ...
    var list = new  [] { &a, &b,&c};
    list.Mutate(x => x + 2);
    Console.WriteLine(a);
