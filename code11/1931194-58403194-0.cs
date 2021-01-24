	[TestMethod]
	public void DocSecurity_Test()
	{
		//https://stackoverflow.com/questions/58335624/is-there-a-programmatically-way-for-excels-protect-workbook
		var fi = new FileInfo(@"c:\temp\DocSecurity_Test.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var package = new ExcelPackage(fi))
		{
			//Create a simple workbook
			var workbook = package.Workbook;
			var worksheet = workbook.Worksheets.Add("Sheet1");
			worksheet.Cells["A1"].Value = "Test";
			//Extended properties is a singleton so reference it to generate the app.xml file
			//needed and add the security setting
			var extProps = workbook.Properties;
			extProps.SetExtendedPropertyValue("DocSecurity", "2");
			//Also need to tell the workbook itself but can only do it via XML
			var xml  = workbook.WorkbookXml;
			var att = xml.CreateAttribute("readOnlyRecommended");
			att.Value = "1";
			const string mainNs = @"http://schemas.openxmlformats.org/spreadsheetml/2006/main";
			var fileSharing = xml.CreateElement("fileSharing", mainNs);
			fileSharing.Attributes.Append(att);
			//Element must be at the beginning of the tree
			xml.DocumentElement.PrependChild(fileSharing);
			package.Save();
		}
	}
