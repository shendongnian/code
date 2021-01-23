    public class Demo
    {
        private readonly CompositionContainer _container;
        [Import]
        public IInterface Dependency { get; set; }
        public Demo(CompositionContainer container)
        {
            _container = container;
        }
        public void Test()
        {
           
            //no exported value, so the next line would cause an excaption
            //var value=_container.GetExportedValue<IInterface>();
            var myClass = new MyClass(_container);
            
            //exporting the needed dependency
            myClass.Export();
            
            _container.SatisfyImportsOnce(this);
            
            //now you can retrieve the type safely since it's been "exported"
            var newValue = _container.GetExportedValue<IInterface>();
        }
    }
    public interface IInterface
    {
        string Name { get; set; }
    }
    [Export(typeof(IInterface))]
    public class MyClass:IInterface
    {
        private readonly CompositionContainer _container;
        public MyClass()
        {
            
        }
        public MyClass(CompositionContainer container)
        {
            _container = container;
        }
        #region Implementation of IInterface
        public string Name { get; set; }
        public void Export()
        {
            _container.ComposeExportedValue<IInterface>(new MyClass());
        }
        #endregion
    }
