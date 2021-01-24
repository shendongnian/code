using System;
using System.Drawing;
					
public class Program
{
	public static System.Random Random = new Random();
	
	static void Main(string[] args)
        {
            // ...
			var color = GetRandomColor();
		    // ...
        }
	
	public static Color GetRandomColor()
	{
		Span<byte> bytes = stackalloc byte[4];
		Random.NextBytes(bytes);
		return Color.FromArgb(bytes[0], bytes[1], bytes[2], bytes[3]);
	}
}
