	var document = XDocument.Parse(xml);
	
	var dictionaries =
		document
			.Root
				.Elements("prop1")
				.Select(prop1 => new
				{
					name = prop1.Attribute("Name").Value,
					children =
						prop1
							.Elements("childprop")
							.Select(childprop => new
							{
								name = childprop.Attribute("Name").Value,
								value = childprop.Attribute("Value").Value
							})
							.StartWith(new
							{
								name = "",
								value = prop1.Attribute("Defaultvalue").Value
							})
				})
				.ToDictionary(
					x => x.name,
					x => x.children.ToDictionary(y => y.name, y => y.value));
