 c#
using System;
using System.Reflection;
using System.Reflection.Emit;
public class SomethingAttribute : Attribute
{
    public SomethingAttribute(string name)
        => Name = name;
    public string Name { get; }
    public void SomeMethod(int i)
    {
        Console.WriteLine($"SomeMethod: {Name}, {i}");
    }
}
public static class P
{
    public static void Foo([Something("Abc")] int x)
    {
        Console.WriteLine($"Foo: {x}");
    }
    public static void Main()
    {
        // get the attribute
        var method = typeof(P).GetMethod(nameof(Foo));
        var p = method.GetParameters()[0];
        var attr = (SomethingAttribute)Attribute.GetCustomAttribute(p, typeof(SomethingAttribute));
        // define an assembly, module and type to play with
        AssemblyBuilder asm = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Evil"), AssemblyBuilderAccess.Run);
        var module = asm.DefineDynamicModule("Evil");
        var type = module.DefineType("SomeType", TypeAttributes.Public);
        // define a field where we'll store our synthesized attribute instance; avoid initonly, unless you're
        // going to write code in the .cctor to initialize it; leaving it writable allows us to assign it via
        // reflection
        var attrField = type.DefineField("s_attr", typeof(SomethingAttribute), FieldAttributes.Static | FieldAttributes.Private);
        // declare the method we're working on
        var bar = type.DefineMethod("Bar", MethodAttributes.Static | MethodAttributes.Public, typeof(void), new[] { typeof(int) });
        var il = bar.GetILGenerator();
        // use the static field instance as our target to invoke the attribute method
        il.Emit(OpCodes.Ldsfld, attrField); // the attribute instance
        il.Emit(OpCodes.Ldarg_0); // the integer
        il.EmitCall(OpCodes.Callvirt, typeof(SomethingAttribute).GetMethod(nameof(SomethingAttribute.SomeMethod)), null);
        // and also call foo
        il.Emit(OpCodes.Ldarg_0); // the integer
        il.EmitCall(OpCodes.Call, typeof(P).GetMethod(nameof(P.Foo)), null);
        il.Emit(OpCodes.Ret);
        // complete the type
        var actualType = type.CreateType();
        // assign the synthetic attribute instance on the concrete type
        actualType.GetField(attrField.Name, BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, attr);
        // get a delegate to the method
        var func = (Action<int>)Delegate.CreateDelegate(typeof(Action<int>), actualType.GetMethod(bar.Name));
        // and test it
        for (int i = 0; i < 5; i++)
            func(i);
    }
}
Output from the final loop (`for (int i = 0; i < 5; i++) func(i);`):
 txt
SomeMethod: Abc, 0
Foo: 0
SomeMethod: Abc, 1
Foo: 1
SomeMethod: Abc, 2
Foo: 2
SomeMethod: Abc, 3
Foo: 3
SomeMethod: Abc, 4
Foo: 4
As a side note; in many ways it is *easier* to do this with expression-trees, since expression-trees have `Expression.Constant` which *can be* the attribute instance, and which is treated like a field internally. But you mentioned `TypeBuilder`, so I went this way :)
