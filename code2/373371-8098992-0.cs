    public static class SimpleUsing
    {
        public static void DoUsing(Action<MyDataContext> action)
        {
            using (MyDataContext db = new MyDataContext())
               Action(db);
        }
    }
    // ...
    SimpleUsing.DoUsing(db => {
        // do whatever with db
    }
