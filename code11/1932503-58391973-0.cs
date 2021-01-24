public static void Main()
{
	var f = 2.0F;
	Print(f);
	f = 2.12345F;
	Print(f);
}
public static void Print(float f) {
	Console.WriteLine(f.ToString("0.0###"));
	Console.WriteLine(f.ToString("0.0"));
	Console.WriteLine(f.ToString("N1"));
	Console.WriteLine(f.ToString("G29"));
}
Output:
2.0
2.0
2.0
2
2.1235
2.1
2.1
2.12345004
