public static class Program
{
    internal static readonly string hello = string.Format("hola {0} {1}", name, 4);
    internal static readonly string name = string.Format("Juan {0}", 4);
    public const int num = 4;
    public static void Main()
    {
        Console.WriteLine(hello);
    }
}
(Courtesy of [SharpLab](https://sharplab.io/#v2:EYLgxg9gTgpgtADwGwBYA+ABATARgLABQ2AzAAQDehp1p2WFVNTGOAnABQAWMANjxAEoA3I2oBfQqNIBLAHYAXGFFkBDHrRxJSsFQBMIsngE8NABlLc+EUgF5SAEgBEnCDxUVVAWxhiPAV08xRxECJjlFZTUNLR19QxMWcy8YajsnACk/FVl/QOCpDDJIWQBneRkFUlkA21IUELEgA==))
Notice how the value of the const is compiled into the places it's used.
---------
When you have static fields that depend on each other, you either need to be very careful with the order that they're declared, or it's normally safer (and more readable!) to just use a static constructor:
public static class Program {
    static Program() {
        name = $"Juan {num}";
        hello = $"hola {name} {num}";
    }
    public static void Main() {
        Console.WriteLine(hello);
    }
    internal static readonly string hello;
    internal static readonly string name;
    public const int num = 4;
}
