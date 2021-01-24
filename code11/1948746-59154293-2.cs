    public class MyObjectClass
        {
    
        }
      public class MyClass
        {
            public MyClass()
            {
                var field = this.GetType().GetField("lazyObjectClass", BindingFlags.NonPublic | BindingFlags.Instance);
                //Get value of field
                Lazy<MyObjectClass> lazyValue = (Lazy<MyObjectClass>)field.GetValue(this);
    
                //Get property MyObject
                var lazyField = this.GetType().GetField("_lazy", BindingFlags.NonPublic | BindingFlags.Instance);
                lazyField.SetValue(this, lazyValue);
    
            }
    
            private Lazy<MyObjectClass> _lazy = null;
            private MyObjectClass myValue = null;
    
            private Lazy<MyObjectClass> lazyObjectClass = new Lazy<MyObjectClass>(() =>
            {
                return new MyObjectClass();
            });
            public MyObjectClass MyObject
            {
                get
                {
                    if (myValue == null)
                    {
                        return _lazy.Value;
                    }
                    else
                    {
                        return myValue;
                    }
    
                }
                set
                {
                    myValue = value;
                }
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                MyClass myClass = new MyClass();
    
                var a = myClass.MyObject;
            }
        }
