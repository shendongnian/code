class MustHaveConstraints<X>
where X : List<string>` 
{
}
But it is useless.
Therefore you can write:
class MustHaveConstraints<T1, T2>
where T1: List<T2>
{
}
var instance1 = new MustHaveConstraints<List<object>, object>();
var instance2 = new MustHaveConstraints<List<int>, int>();
var instance3 = new MustHaveConstraints<List<string>, string>();
var instance4 = new MustHaveConstraints<List<bool[]>, bool[]>();
----------
static void Test()
{
  var arr1 = new int[10];
  var arr2 = new List<int>[10];
  var arr3 = new Data[10];
  var instance = new List<int>();
}
public struct Data
{
  public int Value;
}
// _ = new int[10];
IL_0000: ldc.i4.s 10
IL_0002: newarr [mscorlib]System.Int32
IL_0007: pop
// _ = new List<int>[10];
IL_0008: ldc.i4.s 10
IL_000a: newarr class [mscorlib]System.Collections.Generic.List`1<int32>
IL_000f: pop
// _ = new Data[10];
IL_0010: ldc.i4.s 10
IL_0012: newarr ConsoleApp.Program/Data
IL_0017: pop
// new List<int>();
IL_0018: newobj instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
https://docs.microsoft.com/dotnet/api/system.reflection.emit.opcodes.newarr
https://docs.microsoft.com/dotnet/api/system.reflection.emit.opcodes.newobj
