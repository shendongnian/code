    namespace IRConstructorParamSpike
    {
        public abstract class BaseDocument
        {
            public BaseDocument(int id) { }
        }
    
        public class Document : BaseDocument
        {
            public Document(int id) : base(id) { }
        }
    
        public class SomeDocument : BaseDocument
        {
            public SomeDocument(int id) : base(id) { }
        }
    }
