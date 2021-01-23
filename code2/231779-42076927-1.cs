	using System.IO;
	using Newtonsoft.Json;
	using NUnit.Framework;
	namespace json_formatter.tests
	{
		[TestFixture]
		internal class FormatterTests
		{
			[Test]
			public void CompareWithNewtonsofJson()
			{
				string file = Path.Combine(TestContext.CurrentContext.TestDirectory, "json", "minified.txt");
				string json = File.ReadAllText(file);
				string newton = JsonPrettify(json);
                // Double space are indent symbols which newtonsoft framework uses
				string my = new Formatter("  ").Format(json);
				Assert.AreEqual(newton, my);
			}
			[Test]
			public void EmptyArrayMustNotBeFormatted()
			{
				var input = "{\"na{me\": []}";
				var expected = "{\r\n\t\"na{me\": []\r\n}";
				Assert.AreEqual(expected, new Formatter().Format(input));
			}
			[Test]
			public void EmptyObjectMustNotBeFormatted()
			{
				var input = "{\"na{me\": {}}";
				var expected = "{\r\n\t\"na{me\": {}\r\n}";
				Assert.AreEqual(expected, new Formatter().Format(input));
			}
			[Test]
			public void MustAddLinebreakAfterBraces()
			{
				var input = "{\"name\": \"value\"}";
				var expected = "{\r\n\t\"name\": \"value\"\r\n}";
				Assert.AreEqual(expected, new Formatter().Format(input));
			}
			[Test]
			public void MustFormatNestedObject()
			{
				var input = "{\"na{me\":\"val}ue\", \"name1\": {\"name2\":\"value\"}}";
				var expected = "{\r\n\t\"na{me\": \"val}ue\",\r\n\t\"name1\": {\r\n\t\t\"name2\": \"value\"\r\n\t}\r\n}";
				Assert.AreEqual(expected, new Formatter().Format(input));
			}
			[Test]
			public void MustHandleArray()
			{
				var input = "{\"name\": \"value\", \"name2\":[\"a\", \"b\", \"c\"]}";
				var expected = "{\r\n\t\"name\": \"value\",\r\n\t\"name2\": [\r\n\t\t\"a\",\r\n\t\t\"b\",\r\n\t\t\"c\"\r\n\t]\r\n}";
				Assert.AreEqual(expected, new Formatter().Format(input));
			}
			[Test]
			public void MustHandleArrayOfObject()
			{
				var input = "{\"name\": \"value\", \"name2\":[{\"na{me\":\"val}ue\"}, {\"nam\\\"e2\":\"val\\\\\\\"ue\"}]}";
				var expected =
					"{\r\n\t\"name\": \"value\",\r\n\t\"name2\": [\r\n\t\t{\r\n\t\t\t\"na{me\": \"val}ue\"\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"nam\\\"e2\": \"val\\\\\\\"ue\"\r\n\t\t}\r\n\t]\r\n}";
				Assert.AreEqual(expected, new Formatter().Format(input));
			}
			[Test]
			public void MustHandleEscapedString()
			{
				var input = "{\"na{me\":\"val}ue\", \"name1\": {\"nam\\\"e2\":\"val\\\\\\\"ue\"}}";
				var expected = "{\r\n\t\"na{me\": \"val}ue\",\r\n\t\"name1\": {\r\n\t\t\"nam\\\"e2\": \"val\\\\\\\"ue\"\r\n\t}\r\n}";
				Assert.AreEqual(expected, new Formatter().Format(input));
			}
			[Test]
			public void MustIgnoreEscapedQuotesInsideString()
			{
                var input = "{\"na{me\\\"\": \"val}ue\"}";
			    var expected = "{\r\n\t\"na{me\\\"\": \"val}ue\"\r\n}";
				Assert.AreEqual(expected, new Formatter().Format(input));
			}
			[TestCase(" ")]
			[TestCase("\"")]
			[TestCase("{")]
			[TestCase("}")]
			[TestCase("[")]
			[TestCase("]")]
			[TestCase(":")]
			[TestCase(",")]
			public void MustIgnoreSpecialSymbolsInsideString(string symbol)
			{
				string input = "{\"na" + symbol + "me\": \"val" + symbol + "ue\"}";
				string expected = "{\r\n\t\"na" + symbol + "me\": \"val" + symbol + "ue\"\r\n}";
				Assert.AreEqual(expected, new Formatter().Format(input));
			}
			[Test]
			public void StringEndsWithEscapedBackslash()
			{
				var input = "{\"na{me\\\\\": \"val}ue\"}";
				var expected = "{\r\n\t\"na{me\\\\\": \"val}ue\"\r\n}";
				Assert.AreEqual(expected, new Formatter().Format(input));
			}
			private static string PrettifyUsingNewtosoft(string json)
			{
				using (var stringReader = new StringReader(json))
				using (var stringWriter = new StringWriter())
				{
					var jsonReader = new JsonTextReader(stringReader);
					var jsonWriter = new JsonTextWriter(stringWriter)
									{
										Formatting = Formatting.Indented
									};
					jsonWriter.WriteToken(jsonReader);
					return stringWriter.ToString();
				}
			}
		}
	}
