    public class FooDataRepository
    {
        public IFooData Insert(Action<IFooData> insertSequence)
        {
            var record = new ConcreteFoo();
            insertSequence.Invoke(record as IFooData);
            this.DataContext.Foos.InsertOnSubmit(record); // Assuming LinqSql in this case..
            return record as IFooData;
        }
    }
