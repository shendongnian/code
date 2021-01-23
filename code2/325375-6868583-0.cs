    public class MyExample
    {
        private readonly IDependency _dependency;
        public MyExample(IDependency dependency)
        {
           _dependency = dependency;
        }
        public IDependency Dependency
        {
          get { return _dependency; }
        }
    }
