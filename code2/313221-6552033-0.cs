    [Export(typeof(IFoo))]
    public class Foo : IFoo, IDisposable
    {
        [Import]
        public IBar Bar { get; set; }
        public void Dispose()
        {
            var barDisposable = Bar as IDisposable;
            if (barDisposable != null) 
                barDisposable.Dispose();
        }
    }
