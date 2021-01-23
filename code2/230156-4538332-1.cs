    using System;
    using System.Linq;
    using System.Xml.Linq
    var xml = "<Setting ...";
    var doc = XElement.Parse(xml);
    int i; // for int parse
    var q = from node in doc.Descendants("PatientFieldSetting")
            let name = node.Attribute("PatientName")
            let length = node.Attribute("PatentFieldLength")
            select new { Name = (name != null) ? name.Value : "", Length = (length != null && Int32.TryParse(length.Value, out i)) ? i : 0 };
    
    foreach (var node in q)
    {
        Console.WriteLine("Name={0}, Length={1}", node.Name, node.Length);
    }
