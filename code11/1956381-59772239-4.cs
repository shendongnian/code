    [MockAspect]
    public class SomeClass
    {
        [PostSharpExecuteAfterMethod]
        public virtual List<string> GimmeSomeData()
        {
            throw new NotImplementedException();
        }
    }
