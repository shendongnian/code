    class Program {
		static void Main(string[] args) {
			MyObject test = new MyObject();
			test.Properties = new Dictionary<string, object>() { { "int", 15 }, { "string", "hi" }, { "number", 7 } };
			Print("Original:", test);
			string json = JsonConvert.SerializeObject(test);
			Console.WriteLine("JSON:\n{0}\n", json);
			MyObject parsed = JsonConvert.DeserializeObject<MyObject>(json);
			Print("Deserialized:", parsed);
		}
		private static void Print(string heading, MyObject obj) {
			Console.WriteLine(heading);
			foreach (var kvp in obj.Properties)
				Console.WriteLine("{0} = {1} of {2}", kvp.Key, kvp.Value, kvp.Value.GetType().Name);
			Console.WriteLine();
		}
	}
