    public class AFooThing : IFooFile, IFooProduct
    {
        private string _fooFileName;
        private string _fooProductName;
    
        string IFooFile.Name => _fooFileName;
        string IFooProduct.Name => _fooProductName;
    
        public AFooThing()
        {
            _fooFileName = "FooFileName";
            _fooProductName = "FooProductName";
        }
    }
