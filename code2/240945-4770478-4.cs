    delegate void AbuseMe(out object foo);
    static void Main() {
        DynamicMethod dyn = new DynamicMethod("Foo",
            typeof(void), new[] { typeof(object).MakeByRefType() });
        dyn.GetILGenerator().Emit(OpCodes.Ret);
        AbuseMe method = (AbuseMe) dyn.CreateDelegate(typeof(AbuseMe));
        object obj; // this **never** gets assigned, by **any** code
        method(out obj);
        Console.WriteLine(obj == null);
    }
