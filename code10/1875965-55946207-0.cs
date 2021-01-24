csharp
using System;
using System.Linq;
using System.Xml.Linq;
class Program
{
    static void Main()
    {
        var document = XDocument.Load("input.xml");
        var points = document.Descendants("navPoint").ToList();
        
        XElement currentPart = null;
        foreach (var point in points)
        {
            var src = point.Element("content").Attribute("src").Value;
            if (src.Contains("#Part"))
            {
                currentPart = point;
            }
            else if (src.Contains("#Chapter"))
            {
                if (point.Parent != currentPart)
                {
                    point.Remove();
                    currentPart.Add(point);
                }
            }
        }
        document.Save("output.xml");
    }
}
This assumes that:
- Every `navPoint` element has a `content` element with a `src` attribute
- There's always a part element before the first chapter element
- It's fine to just move chapter elements to the end within the current part element
