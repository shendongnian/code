    public static class SimpleUsing
    {
        public static void DoUsing(Action<MyDataContext> action)
        {
            using (MyDataContext db = new MyDataContext())
               action(db);
        }
        public static T DoUsing(Func<MyDataContext, T> fn)
        {
            using (MyDataContext db = new MyDataContext())
               return fn(db);
        }
    }
    // ...
    SimpleUsing.DoUsing(db => {
        // do whatever with db
    });
    var result = SimpleUsing.DoUsing(db => {
        return 42; // uses Func overload, result will be 42
    });
