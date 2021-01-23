		public static string[] FindPathToProperty(object item, string propertyValueToFind)
		{
			var pathToProperty = new Stack<string>();
			var visitedObjects = new HashSet<object> {item};
			FindPathToProperty(item, propertyValueToFind, pathToProperty, visitedObjects);
			var finalPath = pathToProperty.ToArray();
			Array.Reverse(finalPath);
			return finalPath;
		}
		private static bool FindPathToProperty(object item, string propertyValueToFind, Stack<string> pathToProperty, HashSet<object> visitedObjects)
		{
			foreach (var property in item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
			{
				try
				{
					var value = property.GetValue(item, null);
					if (visitedObjects.Contains(value))
					{
						continue;						
					}
					visitedObjects.Add(value);
					pathToProperty.Push(property.Name);
					bool found = false;
					try
					{
						found = propertyValueToFind.Equals(value) ||
						        FindPathToProperty(value, propertyValueToFind, pathToProperty, visitedObjects);
					}
					finally
					{
						if (!found)
						{
							pathToProperty.Pop();
						}
					}
					if (found)
					{
						return true;
					}
				}
				catch
				{
					continue;
				}
			}
			return false;
		}
		public static void Test()
		{
			Test(new { X = "find" }, "X");
			Test(new { X = "no", Y = "find" }, "Y");
			Test(new { A = new { X = "no", Y = "find" } }, "A.Y");
		}
		private static void Test(object item, string expected)
		{
			string actual = string.Join(".", FindPathToProperty(item, "find"));
			Console.WriteLine("{0} : {1}\r\n      {2}",
							  actual == expected ? "ok " : "BAD",
							  expected,
							  actual);
		}
