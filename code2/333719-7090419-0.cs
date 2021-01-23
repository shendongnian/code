        public class MyClass
        {
    
            public object this[string PropertyName]
            {
                get
                {
                    Type myType = typeof(MyClass);
                    System.Reflection.PropertyInfo pi = myType.GetProperty(PropertyName);
                    return pi.GetValue(this, null); //not indexed property!
                }
                set
                {
                    Type myType = typeof(MyClass);
                    System.Reflection.PropertyInfo pi = myType.GetProperty(PropertyName);
                    pi.SetValue(this, value, null); //not indexed property!
                }
            }
        }
