    public class YourServiceClass : YourServiceContract
    {
        [Import]
        private IContract Implementation { get; set; }
        private DirectoryCatalog _directoryCatalog = null;
        private CompositionContainer _container = null;
        public YourServiceClass()
        {
            _directoryCatalog = new DirectoryCatalog(YourDirectoryPathHere);
            _container = new CompositionContainer(_directoryCatalog);
            _container.ComposeParts(this);
        }
        //Operation
        public void DoSomething()
        {
            Implementation.DoSomething();
        }
    }
