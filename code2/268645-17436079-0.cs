    public class FakeDynamicMethodInvoker : DynamicObject
    {
        // your code here
    }
    public class FakeDynamicWrapper<T>
    {
        static FakeDynamicWrapper()
        {
            DynamicStaticField = (dynamic)new FakeDynamicMethodInvoker();
        }
        public static T DynamicStaticField{ get; set; }
    }
    public class RealClassWithDynamicStaticField: FakeDynamicWrapper<dynamic>
    {
    
    }
