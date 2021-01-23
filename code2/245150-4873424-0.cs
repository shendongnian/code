    [Test]
    public void myClass_must_have_one_single_paramter_ctor()
    {
        Type type = typeof(MyClass);
        const BindingFlags Flags = (BindingFlags.Public | BindingFlags.Instance);
        ConstructorInfo[] ctors = type.GetConstructors(Flags);
        Assert.AreEqual(1, ctors.Length, "Ctor count.");
        ParameterInfo[] args = ctors[0].GetParameters();
        Assert.AreEqual(1, args.Length, "Ctor parameter count.");
        Assert.AreEqual(typeof(string), args[0].ParameterType, "Ctor parameter type.");
    }
    public class MyClass
    {
        public MyClass(string woo) {}
    }
