using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		string input = "22-74-68-64-62-32-75-74-71-53-5A-6D-44-32-65-61-38-39-43-6A-39-4A-41-3D-3D-22";
		
		//Split string by '-'
		string[] spl = input.Split('-');
		
		//Parse bytes and add them to a list
		List<byte> buf = new List<byte>();
		foreach(string s in spl) {
			buf.Add(byte.Parse(s, System.Globalization.NumberStyles.HexNumber));
		}
		
		//Convert list to byte[]
		byte[] bytes = buf.ToArray();
		
		//Print byte[] into console
		foreach(byte b in bytes)
			Console.WriteLine(b.ToString("X2"));
	}
}
[DotNetFiddle](https://dotnetfiddle.net/HZCsBP)
