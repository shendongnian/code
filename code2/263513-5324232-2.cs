    var xmlDocument = new XDocument(
      new XElement(
        "Categories",
        categories.Select(
          c => new XElement(
            "Category",
            new XAttribute("ID", c.Id),
            new XElement("CategoryName", c.Name),
            new XElement("Products",
              c.Products.Select(
                p => new XElement(
                  "Product",
                  new XElement("ProductName", p.Name)
                )
              )
            )
          )
        )
      )
    );
