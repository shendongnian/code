    public class MyClass
    {
        private Lazy<MyObjectClass> lazyObjectClass = new Lazy<MyObjectClass>(() => new MyObjectClass());
        private MyObjectClass <MyObject>k__BackingField;
        public MyObjectClass MyObject 
        { 
           get 
           {
              return <MyObject>k__BackingField;
           }
           set
           {
              <MyObject>k__BackingField = value;
           }
        }
    }
