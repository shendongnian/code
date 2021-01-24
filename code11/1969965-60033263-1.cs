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
The above code will cause an exception if the input is not a perfect string of bytes delimited by dashes. If you're not expecting a perfect input you'll have to use `byte.TryParse` like so:
using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		string input = "22-74-68-64-62-32-75-74-71-53-5A-XX-wrgererh-6D-44-32-65-61-38-39-43-6A-39-4A-41-3D-3D-22";
		
		//Split string by '-'
		string[] spl = input.Split('-');
		
		//Parse bytes and add them to a list
		List<byte> buf = new List<byte>();
		byte tb;
		foreach(string s in spl) {
			if(byte.TryParse(s, System.Globalization.NumberStyles.HexNumber, null, out tb))
				buf.Add(tb);
		}
		
		//Convert list to byte[]
		byte[] bytes = buf.ToArray();
		
		//Print byte[] into console
		foreach(byte b in bytes)
			Console.WriteLine(b.ToString("X2"));
	}
}
[DotNetFiddle](https://dotnetfiddle.net/39I7V5)
