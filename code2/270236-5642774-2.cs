// T must be of delegate type (Func&lt;T&gt;, Func&lt;T1, T2&gt;, etc.)
public static T GetCompiledDelegate&lt;T&gt;(Expression&lt;T&gt; expr)
{
    var assemblyName = new AssemblyName("DelegateHostAssembly") { Version = new Version("1.0.0.0") };
    var assemblyBuilder = 
        AppDomain.CurrentDomain.DefineDynamicAssembly(
            assemblyName, 
            AssemblyBuilderAccess.RunAndSave);
    var moduleBuilder = assemblyBuilder.DefineDynamicModule("DelegateHostAssembly", "DelegateHostAssembly.dll");
    var typeBuilder = moduleBuilder.DefineType("DelegateHostAssembly." + "foo", TypeAttributes.Public);
    var methBldr = typeBuilder.DefineMethod("Execute", MethodAttributes.Public | MethodAttributes.Static);
    expr.CompileToMethod(methBldr);
    Type myType = typeBuilder.CreateType();
    var mi = myType.GetMethod("Execute");
    // have to box to object because .NET doesn't allow Delegates as generic constraints,
    // nor does it allow casting of Delegates to generic type variables like "T"
    object foo = Delegate.CreateDelegate(typeof(T), mi);
    return (T)foo;
}
