    public static void GetObjectsV2(Expression<Func<Bar, bool>> whereFunc, Expression<Func<Bar, string>> selectPropFunc)
    {
        using(MyContext context = new MyContext())
        {
             var objects = context.Bars.Where(whereFunc)
                           .Select(b => new MyObject{Prop = selectPropFunc(b), Name = b.Name})
                           .ToList();
             foreach(var object in objects)
             {
                 // do something with the object
             }
        }
    }
