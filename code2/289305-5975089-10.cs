    var xml = "<myPrefix:Catalog xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:sys=\"clr-namespace:System;assembly=mscorlib\" xmlns:myPrefix=\"clr-namespace:........\"><myPrefix:Item Name=\"MyName\" Mode=\"MyMode\" /></myPrefix:Catalog>";
    XNamespace presentation = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
    XNamespace xaml = "http://schemas.microsoft.com/winfx/2006/xaml";
    XNamespace mscorlib = "clr-namespace:System;assembly=mscorlib";
    XNamespace myPrefix = "clr-namespace:.......";
    XElement container = XElement.Parse(xml);
    var xmlTree= new XElement("Item",
			       new XAttribute("Name", "MyName1"),
			       new XAttribute("Mode", "MyMode1"));
    xmlTree.Add(xmlNode);
    foreach (var el in xmlTree.DescendantsAndSelf())
    {
      el.Name = myPrefix.GetName(el.Name.LocalName);
      var atList = el.Attributes().ToList();
      el.Attributes().Remove();
      foreach (var at in atList)
      {
        if (el.Name.LocalName == "Catalog" && at.Name.LocalName != "xmlns")
          continue;
        el.Add(new XAttribute(at.Name.LocalName, at.Value));
      }
    }
    xmlTree.Add(new XAttribute(XNamespace.Xmlns + "x", xaml));
    xmlTree.Add(new XAttribute(XNamespace.Xmlns + "sys", mscorlib));
    xmlTree.Add(new XAttribute(XNamespace.Xmlns + "myPrefix", myPrefix));
