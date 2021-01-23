	var books = from book in booksXml.Descendants("book")
				select new
				{
					Name = book.Attribute("name")?.Value ?? String.Empty,
					Price = Convert.ToInt32(book.Attribute("price")?.Value ?? "0"),
					Special = book.Attribute("special")?.Value ?? String.Empty
				};
