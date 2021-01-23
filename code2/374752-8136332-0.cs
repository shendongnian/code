		public static void Main()
		{
			var searchValue = "54";
			var xdoc = XDocument.Load(@"foo.xml");
			XNamespace nsD = "http://schemas.microsoft.com/ado/2007/08/dataservices";
			XNamespace nsM = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";
			XNamespace nsDefault = "http://www.w3.org/2005/Atom";
			var foundElem = xdoc.Root
				.Elements(nsDefault + "entry")
				.Elements(nsDefault + "content")
				.Elements(nsM + "properties")
				.Elements(nsD + "LastID")
				.Where(e => e.Value == searchValue)
				.FirstOrDefault();
			if (foundElem != null)
			{
			    var siblingElems = foundElem.Parent.Elements();
			    foreach (var elem in siblingElems)
			    {
			        Console.WriteLine("{0} = {1}", elem.Name, elem.Value);
			    }
			}
		}
