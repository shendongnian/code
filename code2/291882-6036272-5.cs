		public enum MyEnum
		{
			[XmlEnumAttribute("Twenty and Something")]
			TwentyTree = 1,
			[XmlEnumAttribute("Thirty and Something")]
			Thirdyfour
		}
		class Foo
		{
			public MyEnum TestProp { get; set; }
			/// <summary>
			/// Get a list of properties that are enum types 
			/// </summary> 
			/// <returns>Enum property names</returns>
			public static string[] GetEnumProperties()
			{
				MemberInfo[] members = typeof(Foo).FindMembers(MemberTypes.Property, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance, null, null);
				List<string> retList = new List<string>();
				foreach (MemberInfo nextMember in members)
				{
					PropertyInfo nextProp = nextMember as PropertyInfo;
					if (nextProp.PropertyType.IsEnum)
						retList.Add(nextProp.Name);
				} return retList.ToArray();
			}
		}
