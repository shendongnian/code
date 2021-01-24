	public static void ReplaceXmlString(this ZipArchive xlsxZip, FileInfo outFile, string oldString, string newstring)
	{
		using (var outStream = outFile.Open(FileMode.Create, FileAccess.ReadWrite))
		using (var copiedzip = new ZipArchive(outStream, ZipArchiveMode.Update))
		{
			//Go though each file in the zip one by one and copy over to the new file - entries need to be in order
			foreach (var entry in xlsxZip.Entries)
			{
				var newentry = copiedzip.CreateEntry(entry.FullName);
				var newstream = newentry.Open();
				var orgstream = entry.Open();
				//Copy non-xml files over
				if (!entry.Name.EndsWith(".xml"))
				{
					orgstream.CopyTo(newstream);
				}
				else
				{
					//Load the xml document to manipulate
					var xdoc = new XmlDocument();
					xdoc.Load(orgstream);
					var xml = xdoc.OuterXml.Replace(oldString, newstring);
					xdoc = new XmlDocument();
					xdoc.LoadXml(xml);
					xdoc.Save(newstream);
				}
				orgstream.Close();
				newstream.Flush();
				newstream.Close();
			}
		}
	}
