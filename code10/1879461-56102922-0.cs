 c#
public static void kryptering(string p)
{
   	int ordTest = p.Length;
	var newArr = new char[ordTest];
   	for (int i = 0; i < ordTest; i++)
   	{
      newArr[i] = Convert.ToChar(p[i] + 1);     
   	}
	Console.Write(new string(newArr));
}
Fiddle here: https://dotnetfiddle.net/XZlbs1
