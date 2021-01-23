	private static void doSomeStuff(HttpPostedFileBase file)
	{
		try
		{
			using (var reader = new MemoryStream(file.ToByteArray()))
			{
				// do some stuff... say read it to xml
				using (var xmlTextReader = new XmlTextReader(reader))
				{                    
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
