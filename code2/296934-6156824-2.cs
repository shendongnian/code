       public class MyAttribute: Attribute 
        {
            private Type _ClassType;
            public MyAttribute(Type classType)
            {
                _ClassType = classType;
            }
            public void SomeMethod<T>() where T: IMyInterface
            {
                var expectedType = Activator.CreateInstance(typeof(T)) as IMyInterface;
            // Do something with expectedType
            }
        }
