xml
<Model xsi:type="SettingsModel" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Name>Test05</Name>
  <IsActive>false</IsActive>
  <IsHidden>false</IsHidden>
</Model>
You can use the following code:
c#
var model = new { Name = "Test05", IsActive = false, IsHidden = false };
var namespaceName = "http://www.w3.org/2001/XMLSchema-instance";
XNamespace xsi = XNamespace.Get(namespaceName);
var x = new XElement("Model",
    new XAttribute(xsi + "type", "SettingsModel"),
    new XAttribute(XNamespace.Xmlns + "xsi", namespaceName),
    new XElement("Name", model.Name),
    new XElement("IsActive", model.IsActive),
    new XElement("IsHidden", model.IsHidden)
    );
Console.WriteLine(x);
LINQ to XML is an exercise in frustration. In the long term you may prefer to use concrete classes with appropriate XML serialization decorators.
