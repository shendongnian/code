XPathDocument pdoc = new XPathDocument("Courses.xml");
XPathNavigator pNav = pdoc.CreateNavigator();
XPathNodeIterator iterator = pNav.Select("/Courses/Course");
while (iterator.MoveNext())
{
    var nameNode = iterator.Current.SelectSingleNode("Name");
    string courseName = nameNode.Value;
    var codeNode = iterator.Current.SelectSingleNode("Code");
    codeNode.MoveToFirstAttribute();
    string courseCode = codeNode.Value;
    Console.WriteLine("{0} {1}", courseName, courseCode);
}
When you get to the `Code` element, you need to move to the first attribute to get the value, otherwise `Value` property will return an empty string
