    public class MyAttribute<T> : Attribute where T : ISomeInterface, new
    {
        public void SomeMethod()
        {
            var expectedType = new T();
            // Do something with expectedType
        }
    }
