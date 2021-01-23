    public abstract class BaseStoredProcedureQuery<TReturn>
    {
        protected abstract TReturn ParseRecord(DbDataReader r);
        protected IEnumerable<TReturn> ParseQuery(IEnumerable<DbDataReader> readers)
        {
            return readers.Select<DbDataReader,TReturn>(ParseRecord).ToList();
        }
    }
    public class Query1 : BaseStoredProcedureQuery<Foo>
    {
        protected override Foo ParseRecord(DbDataReader r)
        {
            return new Foo
                       {
                           x = r.Get<int>("x"),
                           y = r.Get<string>("y"),
                           z = r.Get<DateTime?>("z"),
                       };
        }
        public IEnumerable<Foo> GetFoo(int x, string y)
        {
            return ParseQuery(GetFoo(x, y));
        }
    }
    
