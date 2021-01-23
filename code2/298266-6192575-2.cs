    public class FooClass
    {
        public void Foo<T> (T t) where T : IInterfaceA, IInterfaceB
        {
            //... do your thing here
        }
        private static void Example(object someObj)
        {
            var type = someObj.GetType();
            if(typeof(IInterfaceA).IsAssignableFrom(type) && typeof(IInterfaceB).IsAssignableFrom(type))
            {
                var genericMethod = typeof(FooClass).GetMethod("Foo");
                var constructedMethod = genericMethod.MakeGenericMethod(type);
                var instance = new FooClass();
                var result = constructedMethod.Invoke(instance, new [] { someObj });
                Assert.IsNull(result);
            }
        }
    }
        
