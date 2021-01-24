c#
var returnObj = JsonConvert.DeserializeObject<Return>(json);
In order for this to work, you need the following package: **Newtonsoft.Json**
The result is as follow:
[![enter image description here][1]][1]
I made a small console app, which shows you the way. It should be the same in Unity:
c#
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
namespace IoException
{
	[System.Serializable]
	public class Menu
	{
		public string id_menu { get; set; }
		public string nome { get; set; }
		public string tipo { get; set; }
	}
	[System.Serializable]
	public class Return
	{
		public string success { get; set; }
		public List<Menu> menus { get; set; }
	}
	public class JsonExercise
	{
		public static void Main(string[] args)
		{
			var currentLine = Console.ReadLine();
			var sb = new StringBuilder();
			while (currentLine != "END")
			{
				sb.AppendLine(currentLine);
				currentLine = Console.ReadLine();
			}
			var json = sb.ToString().Trim();
			var returnObj = JsonConvert.DeserializeObject<Return>(json);
			Console.WriteLine();
		}
	}
}
Notes about the console app, in case you want to try it:
 - When you enter the JSON, enter "END" as the last line, in order for the console app to stop reading.
 - For the input JSON, I used the one that you provided.
  [1]: https://i.stack.imgur.com/8Pw1z.png
