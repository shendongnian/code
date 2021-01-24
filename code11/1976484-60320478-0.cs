csharp
public static void Main()
{
	checked
	{
		int i1 = 256741038, i2 = 623958417, i3 = 467905213, i4 = 714532089, i5 = 938071625;
		long l1 = 256741038, l2 = 623958417, l3 = 467905213, l4 = 714532089, l5 = 938071625;
		long result1 = i2 + i3 + i4 + i5;
		long result2 = l2 + l3 + l4 + l5;
		long result3 = (long)l2 + (long)l3 + (long)l4 + (long)l5;
		Console.WriteLine(result1);
		Console.WriteLine(result2);
		Console.WriteLine(result3);
		Console.Read();
	}
}
