using System;
using System.Diagnostics;
public class Program
{
	public static void Main()
	{
		int seconds = (int)Math.Floor((DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime()).TotalSeconds);
		int timestampSeconds = seconds % 60;
		int timestampMinutes = (int)Math.Floor((double)(seconds / 60)) % 60;
		int timestampHours = (int)Math.Floor((double)(seconds / 3600));
		Console.WriteLine(timestampHours.ToString() + ":" +
						  timestampMinutes.ToString().PadLeft(2, '0') + ":" +
						  timestampSeconds.ToString().PadLeft(2, '0'));
	}
}
