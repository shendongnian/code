        public interface IInterface{}
        
        public class ClassA : IInterface{}
    
        public class ClassB
        {
            private readonly List<ClassA> _classAs;
    
            public IEnumerable<IInterface> Data{ get { return _classAs; } }
        }
