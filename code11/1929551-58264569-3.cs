    static void Main(string[] args)
    {
        Type myFirstFooType = typeof(MyFirstFoo);
        // locate the underlying methodinfo, properties have get and set methods.
        PropertyInfo myFirstStaticValueMethod = myFirstFooType.GetProperty("StaticValue");
        MethodInfo getMethod = myFirstStaticValueMethod.GetGetMethod();
        // we need to generate a method call that is non-virtual to a virtual method
        // this is normally not allowed in C# because it is prone to error and brittle.
        // Here we directly emit IL to do so.
        var method = new DynamicMethod("NonVirtualGetter", typeof(string), Type.EmptyTypes, typeof(MyFirstFoo), true);
        var ilgen = method.GetILGenerator();
        ilgen.Emit(OpCodes.Ldnull); // load a null value for the receiver
        ilgen.Emit(OpCodes.Call, getMethod); // invoke the getter method
        ilgen.Emit(OpCodes.Ret);
        // generate a delgate to the dynamic method.
        var getter = (Func<string>)method.CreateDelegate(typeof(Func<string>));
        string result = getter();
        Console.WriteLine("MyFirstFoo.StaticValue == " + result);
    }
