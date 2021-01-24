cs
public TEnum ObjectCast()
{
    return (TEnum)(object)0;
}
box `int` value into `object` and then unbox into `TEnum` value, since it's value type
IL_0001: ldc.i4.0
IL_0002: box          [System.Runtime]System.Int32
IL_0007: unbox.any    TestConsoleApp.Test/TEnum
IL_000c: stloc.0      // V_0
IL_000d: br.s         IL_000f
I guess that it's a main reason of the slowest execution in comparison with other samples.
The `dynamic` object cast
cs
public TEnum DynamicCast()
{
    return (TEnum) (dynamic) 0;
}
looks more complicated
IL_0001: ldsfld       class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite`1<class [System.Runtime]System.Func`3<class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite, object, valuetype TestConsoleApp.Test/TEnum>> TestConsoleApp.Test/'<>o__0'::'<>p__0'
IL_0006: brfalse.s    IL_000a
IL_0008: br.s         IL_002f
IL_000a: ldc.i4.s     16 // 0x10
IL_000c: ldtoken      TestConsoleApp.Test/TEnum
IL_0011: call         class [System.Runtime]System.Type [System.Runtime]System.Type::GetTypeFromHandle(valuetype [System.Runtime]System.RuntimeTypeHandle)
IL_0016: ldtoken      TestConsoleApp.Test
IL_001b: call         class [System.Runtime]System.Type [System.Runtime]System.Type::GetTypeFromHandle(valuetype [System.Runtime]System.RuntimeTypeHandle)
IL_0020: call         class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSiteBinder [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.Binder::Convert(valuetype [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags, class [System.Runtime]System.Type, class [System.Runtime]System.Type)
IL_0025: call         class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite`1<!0/*class [System.Runtime]System.Func`3<class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite, object, valuetype TestConsoleApp.Test/TEnum>*/> class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite`1<class [System.Runtime]System.Func`3<class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite, object, valuetype TestConsoleApp.Test/TEnum>>::Create(class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSiteBinder)
IL_002a: stsfld       class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite`1<class [System.Runtime]System.Func`3<class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite, object, valuetype TestConsoleApp.Test/TEnum>> TestConsoleApp.Test/'<>o__0'::'<>p__0'
IL_002f: ldsfld       class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite`1<class [System.Runtime]System.Func`3<class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite, object, valuetype TestConsoleApp.Test/TEnum>> TestConsoleApp.Test/'<>o__0'::'<>p__0'
IL_0034: ldfld        !0/*class [System.Runtime]System.Func`3<class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite, object, valuetype TestConsoleApp.Test/TEnum>*/ class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite`1<class [System.Runtime]System.Func`3<class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite, object, valuetype TestConsoleApp.Test/TEnum>>::Target
IL_0039: ldsfld       class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite`1<class [System.Runtime]System.Func`3<class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite, object, valuetype TestConsoleApp.Test/TEnum>> TestConsoleApp.Test/'<>o__0'::'<>p__0'
IL_003e: ldc.i4.0
IL_003f: box          [System.Runtime]System.Int32
IL_0044: callvirt     instance !2/*valuetype TestConsoleApp.Test/TEnum*/ class [System.Runtime]System.Func`3<class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite, object, valuetype TestConsoleApp.Test/TEnum>::Invoke(!0/*class [System.Linq.Expressions]System.Runtime.CompilerServices.CallSite*/, !1/*object*/)
IL_0049: stloc.0      // V_0
IL_004a: br.s         IL_004c
There is a type information loaded, then instance of `CallSiteBinder` is initialized using `Binder.Convert` [static method.][1] Then an instance of generic `CallSite` [class][2] is created, using `Create` [static call][3] (`ldsfld` pushes the value of static field into the stack). I'm not 100% sure, but the generic argument `Func<CallSite, object, TEnum` means a function, which will be invoked to convert the object into `TEnum`. Last lines show that this function is bound to `TEnum` class. 
So, under the hood compiler already creates you a method to cast a dynamic object to required `TEnum` type. And there is only boxing operation from `int` to `object` to pass it to created function. This sounds like a good reason, why it's faster than object cast with boxing and unboxing operations
  [1]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.csharp.runtimebinder.binder.convert?view=netframework-4.8
  [2]: https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callsite-1?view=netcore-3.1
  [3]: https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callsite-1.create?view=netcore-3.1
