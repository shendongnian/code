using System.Xml.Linq;
using System.Xml.XPath;
...
static void Main(string[] args)
{
    XDocument doc = XDocument.Load(new FileStream(@"C:\path_to\input.xml", FileMode.Open));
    string desrcription = doc.XPathSelectElement("/Response/Outcome/KeyValueOfstringOutcomepQnxSKQu[Key='IconDescription']/Value/Value").Value;
    Console.WriteLine(desrcription);
    Console.ReadLine();
}
