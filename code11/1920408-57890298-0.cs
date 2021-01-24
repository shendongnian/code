c#
var doc = XDocument.Load(file);
var list = new System.Collections.Generic.List<DtoHeader>();
foreach (var n in doc.Descendants().First(node => node.Name.LocalName == "Results").Elements().Where(e => e.Name.LocalName == "UnitTestResult"))
{
    list.Add(new DtoHeader
    {
        outcome = n.Attribute("outcome").Value,
        testName = n.Attribute("testName").Value,
    });
}
