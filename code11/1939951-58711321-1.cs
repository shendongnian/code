Class1 o1 = new Class1(15);
Class2 o2 = new Class2();
o2.Object1 = o1;
var x = o2.Object1 as Class1;
//If o2.Object1 is not Class1 x will be null.  
Console.WriteLine(x.Value1); 
# Making `Class2` generic
public class Class1
{
    public Class1(int value1) { Value1 = value1; }
    public int Value1 { get; set; }
}
public class Class2<T>
{
    public T Object1 { get; set; }
}
public static async Task Main()
{
    var o1 = new Class1(15);
    var o2 = new Class2<Class1>();
    o2.Object1 = o1;
    Console.WriteLine(o2.Object1.Value1);
}
