MagicClass.ItsMagic() returned: 900, type: System.Int32
Object of type 'System.String' cannot be converted to type 'System.Int32'.
public class MagicClass
{
	private int magicBaseValue;
	public MagicClass() { magicBaseValue = 9; }
	public int ItsMagic(int preMagic) { return preMagic * magicBaseValue; }
}
public static void Main(string[] args)
{
	var m = new MagicClass();
	MethodInfo magicMethod = m.GetType().GetMethod("ItsMagic");
	object magicValue = magicMethod.Invoke(m, new object[] { 100 });
	Console.WriteLine($"MagicClass.ItsMagic() returned: {magicValue}, type: {magicValue.GetType()}");
	try
	{
		object magicValue2 = magicMethod.Invoke(m, new object[] { "One hundred" });
	} catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
}
MagicClass is borrowed from [MethodBase.Invoke Method ](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.methodbase.invoke?view=netframework-4.8#System_Reflection_MethodBase_Invoke_System_Object_System_Object___)'s doco.
