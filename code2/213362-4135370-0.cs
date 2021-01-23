	private CatalogProduct Load()
	{
		var serializer = new XmlSerializer(typeof(CatalogProduct));
		using (var xmlReader = new XmlTextReader("CatalogProduct.xml"))
		{
			if (serializer.CanDeserialize(xmlReader))
			{
				return serializer.Deserialize(xmlReader) as CatalogProduct;
			}
		}
	}
	private void Save(CatalogProduct cp)
	{
		using (var fileStream = new FileStream("CatalogProduct.xml", FileMode.Create))
		{
			var serializer = new XmlSerializer(typeof(Preferences));
			serializer.Serialize(fileStream, cp);
		}
	}
