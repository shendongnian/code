    public class MyTypeOfXService
    {
        private DataDataContext Context;
        public MyTypeOfXService()
        {
            Context = new DataDataContext("example code");
        }
        public IQueryable<MyTypeOfX> GetTypeOfX(Expression<Func<MyTypeOfX, bool>> where)
        {
            return this.Context.MyTypeOfXes.Where(where);
        }
    }
