	namespace DifferentNamespace
	{
		class A
		{
			public static string foo = "hello";
		}
	}
	
	class Program {
		static void Main(string[] args) {
			Type type = typeof(DifferentNamespace.A);
			FieldInfo[] fields = type.GetFields();
			foreach (var field in fields)
			{
				string name = field.Name;
				object temp = field.GetValue(null); // Get value
                                                    // since the field is static 
                                                    // the argument is ignored
                                                    // so we can as well pass a null				
				if (name == "foo") // See if it is a string.
				{
					string value = temp as string;
					Console.Write("string {0} = {1}", name, value);
				}
				Console.ReadLine();
			}
		}
	}
