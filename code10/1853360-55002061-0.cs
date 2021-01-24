	using (var fs = new FileStream(docxFile, FileMode.Open))
	{
		using (var archive = new ZipArchive(fs, ZipArchiveMode.Update))
		{
			foreach (var entry in archive.Entries)
			{
				if (entry.Name == "[Content_Types].xml")
				{
					using (var entryStream = entry.Open())
					{
						var doc = new XmlDocument();
						doc.Load(entryStream);
						var element = doc.CreateElement("Override");
						element.SetAttribute("PartName", "/docProps/example.xml");
						doc.DocumentElement.AppendChild(element);
						doc.Save(entryStream);
						entryStream.Flush();
					}
					break;
				}
			}
		}
	}
