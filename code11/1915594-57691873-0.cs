// you can load xml from string or however you have it
var xDoc = XDocument.Load(@"c:\temp\myxml.xml"); 
foreach (var nameElement in xDoc.XPathSelectElements("//testing/names/name[type='4']"))
{
    nameElement
        .Descendants("name")
        .Single()
        .Value += " Smith";
}
Alternatively, this approach will iterate on all of the `name` elements under the parent element `names`, and allow you to switch on the value of the `type` element to perform a different action in each case:
// select the name elements, and parse the type into an integer (optional, you can 
// switch on type as a string if you prefer).
var nameElements = xDoc
    .Element("testing")
    .Element("names")
    .Elements("name")
    .Select(name => new { Type = int.Parse(name.Element("type").Value), Element = name });
// iterate on each name element
foreach (var nameElement in nameElements)
{
    // check the type
    switch (nameElement.Type)
    {
        case 4:
            nameElement
                .Element
                .Descendants("name") // filter to name elements under the parent name element
                .Single() // we only expect one
                .Value += " Smith"; // append a last name
            break;
        default:
            continue; // don't do anything
    }
}
