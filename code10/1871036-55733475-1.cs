	using System;
	using System.Collections;
	using System.Collections.Generic;
	namespace ConsoleApp8
	{
		class Program
		{
			static void Main(string[] args)
			{
				var Dic = new Dictionary<int, string> { { 1, "A" }, { 2, "B" } };
				Console.WriteLine(Dic.PrettyToString());
				var Dic1 = new Dictionary<string, float> { { "A", 12.5f }, { "B", 99.9f } };
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
					result += $"({PrettyToString(Key)}, {PrettyToString(dictionary[Key])}) ";
				}
				result += "}";
				return result;
			}
			public static string PrettyToString(this IEnumerable list)
			{
				string result = "{";
				foreach (var element in list)
				{
					result += $"{PrettyToString(element)}, ";
				}
				result += "}";
				return result;
			}
			private static string PrettyToString(object O)
			{
				switch (O)
				{
				case String S: return S;
				case IDictionary D:
					return D.PrettyToString();
				case IEnumerable L:
					return L.PrettyToString();
				default:
					return O.ToString();
				}
			}
		}
	}
