    public class JSObject : DynamicObject
    {
        class TestClassProxy : TestClass
        {
            private dynamic wrapper;
            public TestClassProxy(dynamic obj)
            {
                wrapper = obj;
                // assign copies of the fields
                message = obj.message;
            }
            // override all required methods and properties
            public override void SampleMethod()
            {
                wrapper.SampleMethod();
            }
            public override int SomeValue
            {
                get { return wrapper.SomeValue; }
                set { wrapper.SomeValue = value; }
            }
            // etc...
        }
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type == typeof(TestClass))
            {
                result = new TestClassProxy(this);
                return true;
            }
            // your other conversions
            return base.TryConvert(binder, out result);
        }
        // etc...
    }
