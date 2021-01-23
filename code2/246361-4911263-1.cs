    class MyClass<U> where U : Proxy<>
    {
        void SomeMethod(U parameter)
        {
            var local = parameter.Value;
            //more code here...
        }
    }
