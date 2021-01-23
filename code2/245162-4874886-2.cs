    public class FooDataRepository
    {
        public IFooData Insert(Action<IFoo> insertSequence)
        {
            var record = new ConcreteFoo();
            insertSequence.Invoke(record as IFoo);
            this.DataContext.Foos.InsertOnSubmit(record); // Assuming LinqSql in this case..
            return record as IFoo;
        }
    }
