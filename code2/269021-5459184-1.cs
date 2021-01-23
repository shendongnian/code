    var output = from el in els
                 join xmlEl in xdoc.Root.Elements("Element") on el.Id equals int.Parse(xmlEl.Element("Id").Value)
                 select new Tuple<Element, XElement>(el, xmlEl);
    foreach(var item in output)
    {
        item.Item2.Add(new XElement("Data", item.Item1.Data));
    }
