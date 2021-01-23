    public static void GetObjectsV2(Expression<Func<Bar, bool>> whereFunc, Expression<Func<Bar, string>> selectPropFunc)
    {
        using(MyContext context = new MyContext())
        {
             var objects = context.Bars.Where(whereFunc)
                           .Select(selectPropFunc)
                           .ToList();
             foreach(var object in objects)
             {
                 // do something with the object
             }
        }
    }
