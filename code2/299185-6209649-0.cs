    public class Class1
    {
    }
    public static class StaticClass1
    {
        public static void MethodA<TZen, TType>(this TZen zen, Expression<Func<TZen, TType>> property, ref TType store, TType value) where TZen : Class1
        {
            // Do whatever here...
        }
    }
    public class Class2 : Class1
    {
        private int _propertyInt;
        public int PropertyInt
        {
            get { return _propertyInt; }
            set { this.MethodA(c2 => c2.PropertyInt, ref _propertyInt, value); }
        }
    }
    public class Class3 : Class2
    {
        private float _propertyFloat;
        public float PropertyFloat
        {
            get { return _propertyFloat; }
            set { this.MethodA(c3 => c3.PropertyFloat, ref _propertyFloat, value); }
        }
    }
