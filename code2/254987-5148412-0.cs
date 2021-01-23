        class MyObject
		{
			public int Property1 { get; set;}
			public string Property2 { get; set; }
		}
		class MyOtherObject
		{
			public int Property3 { get; set; }
			public string Property4 { get; set; }
		}
		static void Main(string[] args)
		{
			Array.ForEach(new[] 
			{ 
				new MyObject { Property1 = 1, Property2 = "P" },
				new MyObject { Property1 = 2, Property2 = "Q" } 
			}, Print);
			Array.ForEach(new[]
			{
				new MyOtherObject { Property3 = 3, Property4 = "R" },
				new MyOtherObject { Property3 = 4, Property4 = "S" } 
			}, Print);
			Console.ReadKey();
		}
		static void Print<T>(T item)
		{
			ObjectPrinter<T>.PrintAction(item, Console.Out);
		}
		static class ObjectPrinter<T>
		{
			public static readonly Action<T, TextWriter> PrintAction = CreatePrintAction();
			private static Action<T, TextWriter> CreatePrintAction()
			{
				ParameterExpression item = Expression.Parameter(typeof(T), "item");
				ParameterExpression writer = Expression.Parameter(typeof(TextWriter), "writer");
				var writeLineMethod = typeof(TextWriter).GetMethod("WriteLine", BindingFlags.Public | BindingFlags.Instance, null, new[] { typeof(string) }, null);
				var concatMethod = typeof(string).GetMethod("Concat", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(object), typeof(object) }, null);
				var writeDashedLine = Expression.Call(
					writer,
					writeLineMethod,
					Expression.Constant(
						new String('-', 50)
					)
				);
				var lambda = Expression.Lambda<Action<T, TextWriter>>(
					Expression.Block(
						writeDashedLine,
						Expression.Block(
							from property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
							where property.GetGetMethod().GetParameters().Length == 0
							select Expression.Call(
								writer,
								writeLineMethod,
								Expression.Call(
									null,
									concatMethod,
									Expression.Constant(
										property.Name + ":"
									),
									Expression.Convert(
										Expression.Property(
											item,
											property
										),
										typeof(object)
									)
								)
							)
						),
						writeDashedLine
					),
					item,
					writer
				);
				return lambda.Compile();
			}
		}
