		private static void Main()
		{
			var xdoc = XDocument.Load(@"C:\temp\foo.xml");
			var itemsToAdd = new[] { "item1", "item2", "item3" };
			// var itemsToAdd = listBox1.Items;
			xdoc.Root.Add(
				new XElement("SAVED",
					new XElement("TITLE",
						itemsToAdd.Select(e => new XElement(e)))));
			xdoc.Save(@"c:\temp\foo2.xml");
		}
