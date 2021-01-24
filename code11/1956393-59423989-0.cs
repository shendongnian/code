using System;
					
public class Program
{
	public static void Main()
	{
		string str = "[12-20-2019 11:27:57, 12-20-2019 11:27:58, 12-20-2019 11:27:59]";
		str = str.Substring(1, str.Length - 2);
		string[] parts = str.Split(',');
		
		foreach(var part in parts) {
			str = str.Trim();
			var date = DateTime.Parse(part);
			Console.WriteLine(date);
		}
	}
}
