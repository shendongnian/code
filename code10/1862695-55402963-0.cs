	public Dictionary<string, HashSet<string>> GetTagsByType(
        ICollection<XmlSchemaObject> schemaObjects,
        string typeName)
	{
		var result = new Dictionary<string, HashSet<string>>();
		var xmlElements = schemaObjects
			.Where(w => w.GetType() == typeof(XmlSchemaElement))
			.ToArray();
		var types = schemaObjects
			.Where(w => w.GetType() == typeof(XmlSchemaComplexType))
			.ToArray();
		foreach (var item in xmlElements)
		{
			var el = (XmlSchemaElement)item;
			if (string.IsNullOrEmpty(el.Name) ||
				el.SchemaTypeName == null ||
				string.IsNullOrEmpty(el.SchemaTypeName.Name))
			{
				continue;
			}
			if (!result.ContainsKey(el.SchemaTypeName.Name))
			{
				result.Add(el.SchemaTypeName.Name, new HashSet<string> { el.Name });
			}
			else
			{
				result[el.SchemaTypeName.Name].Add(el.Name);
			}
		}
		foreach (var type in types)
		{
			var t = (XmlSchemaComplexType)type;
			if (t.Particle == null)
			{
				continue;
			}
			var isSubClassOfGroupBase = t.Particle.GetType()
				.IsSubclassOf(typeof(XmlSchemaGroupBase));
			if (!isSubClassOfGroupBase)
			{
				continue;
			}
			var items = ((XmlSchemaGroupBase)t.Particle)
                .Items
				.OfType<XmlSchemaObject>()
				.ToArray();
			var res = GetTagsByType(items, typeName);
			foreach (var item in res.Keys)
			{
				if (result.ContainsKey(item))
				{
					foreach (var r in res[item])
					{
						result[item].Add(r);
					}
				}
				else
				{
					result.Add(item, res[item]);
				}
			}
		}
		return result;
	}
