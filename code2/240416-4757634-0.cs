Reference Microsoft.VisualBasic and you can use [TextFieldParser][1], which almost certainly has less dependencies than your proposed method.
	using (var parser =
		new TextFieldParser(@"c:\data.csv")
			{
				TextFieldType = FieldType.Delimited,
				Delimiters = new[] { "," }
			})
	{
		while (!parser.EndOfData)
		{
			string[] fields;
			fields = parser.ReadFields();
			//go go go!
		}
	}
