    XNamespace presentation = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
    XNamespace xaml = "http://schemas.microsoft.com/winfx/2006/xaml";
    XNamespace mscorlib = "clr-namespace:System;assembly=mscorlib";
    XNamespace myPrefix = "clr-namespace:.......";
    var xmlTree = new XElement(presentation + "Catalog",
                               new XAttribute(XNamespace.Xmlns + "x", xaml),
                               new XAttribute(XNamespace.Xmlns + "sys", mscorlib),
                               new XAttribute(XNamespace.Xmlns + "myPrefix", myPrefix),
                               new XElement(myPrefix + "Item",
                                            new XAttribute("Name", "MyName1"),
                                            new XAttribute("Mode", "MyMode1")),
                               new XElement(myPrefix + "Item",
                                            new XAttribute("Name", "MyName2"),
                                            new XAttribute("Mode", "MyMode2")));
