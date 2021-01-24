    var zipListBox = new List<string>();
	using (var archive = ZipFile.Open(fullFileName, ZipArchiveMode.Read))
	{
		foreach (var entry in archive.Entries)
		{
			if (Path.GetExtension(entry.Name).Equals(".xml", StringComparison.OrdinalIgnoreCase))
			{
				using (var zipEntryStream = entry.Open())
				using (var reader = XmlReader.Create(zipEntryStream))
				{
					// Move to the root element
					reader.MoveToContent();
					var query = reader
						// Read all child elements <Widget>
						.ReadElements("Widget", "")
						// And extract the text content of their first child element <Description>
						.SelectMany(r => r.ReadElements("Description", "").Select(i => i.ReadElementContentAsString()).Take(1));
					zipListBox.AddRange(query);
				}
			}
		}
	}
