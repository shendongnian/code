    using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
						
	public class Program
	{
		public static void Main()
		{
			var jsonData ="{\"Command\":\"te\",\"Data\":{\"Image\":\"/6D/ogARAP8\",\"Imagetype\":\"FLS\",\"Imageformat\":\"bmp\",\"MissingFingers\":[\"FLIF\",\"FLMF\"]}}";
			var jsonRootObject = JsonConvert.DeserializeObject<RootObject>(jsonData);
			Console.WriteLine(jsonRootObject.Data.MissingFingers[0]);
		    Console.WriteLine(jsonRootObject.Data.Imagetype);
		    Console.WriteLine(jsonRootObject.Data.Image);
		}
		public class Data
		{
			public string Image { get; set; }
			public string Imagetype { get; set; }
			public string Imageformat { get; set; }
			public List<string> MissingFingers { get; set; }
		}
		public class RootObject
		{
			public string Command { get; set; }
			public Data Data { get; set; }
		}
	}
