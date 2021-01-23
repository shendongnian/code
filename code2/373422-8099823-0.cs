    public static class SimpleUsing
    {
        public static void DoUsing(Action<MyDataContext> action)
        {
            using (MyDataContext db = new MyDataContext())
               action(db);
        }
    }
