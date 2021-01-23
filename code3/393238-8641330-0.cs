    using System.Linq; // requires assembly reference to System.Core.dll
    using System.Xml.Linq; // requires assembly reference to System.Xml.Linq.dll
    // ...
    XDocument document = XDocument.Load("yourfile.xml");
    var book =
        (from b in document.Descendants("book")
        select new
        {
            Id = b.Attribute("id").Value,
            Author = b.Element("author").Value,
            Title = b.Element("title").Value
        }).First();
