	using System;
	using System.Collections;
	using System.Collections.Generic;
	namespace ConsoleApp8
	{
		class Program
		{
			static void Main(string[] args)
			{
				var Dic = new Dictionary<int, string> { { 1, "Ali" }, { 2, "B" } };
				Console.WriteLine(Dic.PrettyToString());
				var Dic1 = new Dictionary<string, float> { { "Ali", 12.5f }, { "B", 99.9f } };
				Console.WriteLine(Dic1.PrettyToString());
				var Dic2 = new Dictionary<List<int>, string>
				{
					{ new List<int> { 1, 2, 3 }, "A" },
					{ new List<int> { 4, 5, 6 }, "B" }
				};
				Console.WriteLine(Dic2.PrettyToString());
				var Dic3 = new Dictionary<Dictionary<string, string>, string>
				{
					{ new Dictionary<string, string> { { "a", "A" }, { "b", "B" } }, "Capital" },
					{ new Dictionary<string, string> { { "1", "1" }, { "2", "4" }, { "4", "16" } }, "Power" }
				};
				Console.WriteLine(Dic3.PrettyToString());
				var Dic4 = new Dictionary<Dictionary<string, string>, List<string>>
				{
					{ new Dictionary<string, string> { { "a", "A" }, { "b", "B" } }, new List<string> { "A", "B" } },
					{ new Dictionary<string, string> { { "1", "1" }, { "2", "4" }, { "4", "16" } }, new List<string> { "1", "2", "4" } }
				};
				Console.WriteLine(Dic4.PrettyToString());
				var L = new List<List<int>>
				{
					new List<int> { 1, 2, 3 },
					new List<int> { 4, 5, 6 }
				};
				Console.WriteLine(L.PrettyToString());
				Console.ReadKey();
			}
		}
		static class Ext
		{
			public static string PrettyToString(this IDictionary dictionary)
			{
				string result = "{";
				foreach (var Key in dictionary.Keys)
				{
					result += string.Format("({0}, {1}) ", PrettyToString(Key), PrettyToString(dictionary[Key]));
				}
				result += "}";
				return result;
			}
			public static string PrettyToString(this IEnumerable list)
			{
				string result = "{";
				foreach (var element in list)
				{
					result += string.Format("{0}, ", PrettyToString(element));
				}
				result += "}";
				return result;
			}
			private static string PrettyToString(object O)
			{
				var S = O as string;
				if (S != null) return S;
				var D = O as IDictionary;
				if (D != null) return D.PrettyToString();
				var L = O as IEnumerable;
				if (L != null) return L.PrettyToString();
				return O.ToString();
			}
		}
	}
