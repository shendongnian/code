    class TestClass
    {
        public TestClass()
        {
            DeprecatedTester.FindDeprecatedMethods(this.GetType());
        }
    
        [Obsolete("SomeDeprecatedMethod is deprecated, use SomeNewMethod instead.")]
        public void SomeDeprecatedMethod() { }
    
        [Obsolete("YetAnotherDeprecatedMethod is deprecated, use SomeNewMethod instead.")]
        public void YetAnotherDeprecatedMethod() { }
    
        public void SomeNewMethod() { }        
    }
    
    public class DeprecatedTester
    {
        public static void FindDeprecatedMethods(Type t)
        {
            MethodInfo[] methodInfos = t.GetMethods();
    
            foreach (MethodInfo methodInfo in methodInfos)
            {
                object[] attributes = methodInfo.GetCustomAttributes(false);
    
                foreach (ObsoleteAttribute attribute in attributes.OfType<ObsoleteAttribute>())
                {
                    Console.WriteLine("Found deprecated method: {0} [{1}]", methodInfo.Name, attribute.Message);
                }
            }
        }
    }
