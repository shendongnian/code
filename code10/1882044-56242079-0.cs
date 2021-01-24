    var client = new AmazonTextractClient("[KEY ID]", "[ACCESS KEY]", Amazon.RegionEndpoint.USEast1); 
    Document MyDocument;
	using (Image image = Image.FromFile(photo))
	{
		using (MemoryStream m = new MemoryStream())
		{
			image.Save(m, image.RawFormat);
			MyDocument = new Document()
			{
				Bytes = m
			};
		}
	}
