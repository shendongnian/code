csharp
private MethodBuilder DefineGetMethod<TInput, TReturn>(TypeBuilder tb, MethodDescriptor methodInfo, Func<TInput, TReturn> dynamicMethod)
{
    var dynamicMethodBuilder = tb.DefineMethod(methodInfo.MethodName,
                MethodAttributes.Public | MethodAttributes.HideBySig,
                methodInfo.ReturnType, methodInfo.InputParameters.Select(x => x.Type).ToArray());
    var ilGenerator = dynamicMethodBuilder.GetILGenerator();
    ilGenerator.Emit(OpCodes.Ldarg_1);
    ilGenerator.Emit(OpCodes.Call, dynamicMethod.Method);
    ilGenerator.Emit(OpCodes.Ret);
    return dynamicMethodBuilder;
}
But if `dynamicMethod` may be an instance method(lambda with be a instance method), it's will be hardly. call the instance method need push the instance onto stack first, but `Emit` only allow push constant value like int, string.
I can only think of one way, declare a field to store `dynamicMethod`, set field value after build type by reflect:
csharp
private Type DefineGetMethod<TInput, TReturn>(TypeBuilder tb, MethodDescriptor methodInfo, Func<TInput, TReturn> dynamicMethod)
{
    var fieldBuilder = tb.DefineField("_func", dynamicMethod.GetType(), FieldAttributes.Private | FieldAttributes.Static);
    var dynamicMethodBuilder = tb.DefineMethod(methodInfo.MethodName,
                MethodAttributes.Public | MethodAttributes.HideBySig,
                methodInfo.ReturnType, methodInfo.InputParameters.Select(x => x.Type).ToArray());
    var ilGenerator = dynamicMethodBuilder.GetILGenerator();
    // load static field _func onto stack
    ilGenerator.Emit(OpCodes.Ldsfld, fieldBuilder);
    // load arg1 onto stack
    ilGenerator.Emit(OpCodes.Ldarg_1);
    // call _func.Invoke(..)
    ilGenerator.Emit(OpCodes.Callvirt, dynamicMethod.GetType().GetMethod("Invoke"));
    ilGenerator.Emit(OpCodes.Ret);
    var type = tb.CreateType();
    var field = type.GetField("_func", BindingFlags.NonPublic | BindingFlags.Static);
    // store dynamicMethod into static field _func
    field.SetValue(null, dynamicMethod);
    return type;
}
**EDIT**
test code:
csharp
class Program
{
    static void Main(string[] args)
    {
        OnlyStaticFunc();
        StaticField();
    }
    static void OnlyStaticFunc()
    {
        Func<string, int> func = int.Parse;
        var assemblyName = new AssemblyName("StaticFuncTest");
        var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);
        var typeBuilder = moduleBuilder.DefineType("Abc", TypeAttributes.Public);
        var methodBuilder = typeBuilder.DefineMethod("Execute", MethodAttributes.Public | MethodAttributes.HideBySig, typeof(int), new[] { typeof(string) });
        var il = methodBuilder.GetILGenerator();
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Call, func.Method);
        il.Emit(OpCodes.Ret);
        var type = typeBuilder.CreateType();
        var abc = Activator.CreateInstance(type);
        var value = ((dynamic)abc).Execute("123");
        Console.WriteLine($"only static func: {value}");
    }
    static void StaticField()
    {
        Func<string, int> func = s => int.Parse(s);
        var assemblyName = new AssemblyName("StaticFieldTest");
        var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);
        var typeBuilder = moduleBuilder.DefineType("Abc", TypeAttributes.Public);
        var fieldBuilder = typeBuilder.DefineField("_func", func.GetType(), FieldAttributes.Private | FieldAttributes.Static);
        var methodBuilder = typeBuilder.DefineMethod("Execute", MethodAttributes.Public | MethodAttributes.HideBySig, typeof(int), new[] { typeof(string) });
        var il = methodBuilder.GetILGenerator();
        il.Emit(OpCodes.Ldsfld, fieldBuilder);
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Callvirt, func.GetType().GetMethod("Invoke"));
        il.Emit(OpCodes.Ret);
        var type = typeBuilder.CreateType();
        var field = type.GetField("_func", BindingFlags.NonPublic | BindingFlags.Static);
        field.SetValue(null, func);
        var abc = Activator.CreateInstance(type);
        var value = ((dynamic)abc).Execute("456");
        Console.WriteLine($"static field: {value}");
    }
}
