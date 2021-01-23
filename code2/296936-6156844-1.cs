    public class MyAttribute : Attribute
    {
        public void SomeMethod<T>() where T : ISomeInterface, new()
        {
            var expectedType = new T();
            // Do something with expectedType
        }
    }
