XPathDocument pdoc = new XPathDocument("Courses.xml");
XPathNavigator pNav = pdoc.CreateNavigator();
var manager = new XmlNamespaceManager(pNav.NameTable);
manager.AddNamespace("cs", "http://xml");
XPathNodeIterator iterator = pNav.Select("/cs:Courses/cs:Course", manager);
while(iterator.MoveNext())
{
    var nameNode = iterator.Current.SelectSingleNode("cs:Name", manager);
    string courseName = nameNode.Value;
    var codeNode = iterator.Current.SelectSingleNode("cs:Code", manager);
    codeNode.MoveToFirstAttribute();
    string courseCode = codeNode.Value;
    Console.WriteLine("{0} {1}", courseName, courseCode);
}
When you get to the `Code` element, you need to move to the first attribute to get the value, otherwise `Value` property will return an empty string
