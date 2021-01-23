    [ComVisible(true)]
    public interface IMyClass
    {
        void MyMethod();
        ...
    }
    [
    ComVisible(true),
    ClassInterface(ClassInterfaceType.None)
    ]
    public MyClass : IMyClass
    {
        ...
        public MyMethod()
        {
            ... implementation 
        }
        void IMyClass.MyMethod()
        {
            try
            {
                this.MyMethod();
            }
            catch(Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }
    }
