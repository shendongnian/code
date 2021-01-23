    var output = from el in els
                 from xmlEl in xdoc.Root.Elements("Element")
                 where el.Id == int.Parse(xmlEl.Element("Id").Value)
                 select new Tuple<Element, XElement>(el, xmlEl);
    foreach(var item in output)
    {
        item.Item2.Add(new XElement("Data", item.Item1.Data));
    }
