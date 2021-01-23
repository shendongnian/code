    public static class SimpleUsing
    {
        public static TResult DoUsing<TResult>(Func<MyDataContext, TResult> action)
        {
            using (MyDataContext db = new MyDataContext())
               return action(db);
        }
    }
