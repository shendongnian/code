	public class MyClass
	{
		public int Property1 { get; set; }
		public int Property2 { get; set; }
		public string Property3 { get; set; }
		public double Property4 { get; set; }
		public string Property5 { get; set; }
		public double PropertyDontCopy { get; set; }
		public string PropertyOnlyClass3 { get; set; }
		public int[] PropertyIgnoreMe { get; set; }
		public string[] StringArray { get; set; }
		public int TestIntToString { get; set; }
		public string TestStringToInt { get; set; }
		# region Static Property Mapping Information
			// this is one possibility for creating and storing the mapping
		   // information: the class uses two dictionaries, one that links 
		   // the other type with a dictionary of mapped properties, and 
		   // one that links the other type with a list of excluded ones.
			public static Dictionary<Type, Dictionary<string, string>>
				PropertyMappings =
					new Dictionary<Type, Dictionary<string, string>>
					{
						{
							typeof(MyClass2),
							new Dictionary<string, string>
							{
								{ "Property3", "Property3WithOtherName" },
								{ "Property5", "Property5WithDifferentName" },
							}
						},
						{
							typeof(MyClass3),
							new Dictionary<string, string>
							{
								{ "Property1", "Prop1" },
								{ "Property2", "Prop2" },
								{ "Property3", "Prop3OtherName" },
								{ "Property4", "Prop4" },
								{ "Property5", "Prop5DiffName" },
								{ "PropertyOnlyClass3", "PropOnlyClass3" },
							}
						},
					};
			public static Dictionary<Type, List<string>>
				UnmappedProperties =
					new Dictionary<Type, List<string>>
					{
						{
							typeof(MyClass2),
							new List<string> 
								{
									"PropertyDontCopy",
									"PropertyOnlyClass3",
									"PropertyIgnoreMe"
								}
						},
						{
							typeof(MyClass3),
							new List<string> 
								{
									"PropertyDontCopy", 
									"PropertyIgnoreMe"
								}
						}
					};
			// this function pulls together an individual property mapping
			public static Tuple<Dictionary<string, string>, List<string>>
				MapInfo<TOtherType>()
				{
					return 
						new Tuple<Dictionary<string,string>,List<string>>
						(
							PropertyMappings[typeof(TOtherType)],
							UnmappedProperties[typeof(TOtherType)]
						);
				}
		#endregion
	}
