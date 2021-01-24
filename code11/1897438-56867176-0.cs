    public class ClassThatUsesMyClass
    {
        private readonly MyClass _myClass;
        public ClassThatUsesMyClass(MyClass myClass)
        {
            _myClass = myClass;
        }
        public async Task<MyResponse> Handle(MyRequest request, 
            CancellationToken cancellationToken)
        {
            // This method uses the _myClass field instead of creating an instance of MyClass
        }
    }
