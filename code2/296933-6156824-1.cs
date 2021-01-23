       public class MyAttribute: Attribute 
        {
            private Type _ClassType;
            public MyAttribute(Type classType)
            {
                _ClassType = classType;
            }
            public void SomeMethod<T>()
            {
                var expectedType = Activator.CreateInstance(typeof(T)) as ICloneable;
            // Do something with expectedType
            }
        }
