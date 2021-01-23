	class A
	{
		public static string foo = "hello";
	}
	
	class Program {
		static void Main(string[] args) {
			Type type = typeof(A);
			FieldInfo[] fields = type.GetFields();
			foreach (var field in fields)
			{
				string name = field.Name; // get field's name
				object temp = field.GetValue(null); // Get value
				
				if(name == "foo") // looking for a field named "foo" 
				{
					string value = temp as string;
					Console.Write("{0} (string) = {1}", name, value);
				}
				Console.ReadLine();
			}
		}
	}
