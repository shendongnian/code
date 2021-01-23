    public class MyAttribute<T>: Attribute where T: MyInterface
    {
        public void SomeMethod()
        {
            var expectedType = Activator.CreateInstance(typeof(T)) as T;
            // Do something with expectedType
        }
    }
