    public class Foo<T>
    {
        IQueryable<T> Query;
        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return this.Query.Where(predicate).FirstOrDefault();
        }
    }
    ...
    Foo<int> foo = new Foo<int>();
    int firstValueUnder100 = foo.Get(x => x <= 100);
