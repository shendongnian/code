    using System;
    using System.Linq;
    using System.Xml.Linq
    var xml = "<Setting ...";
    var nodes = XElement.Parse(xml);
    var q = from node in nodes.Descendants("PatientFieldSetting")
            let name = node.Attribute("PatientName")
            let length = node.Attribute("PatentFieldLength")
            select new { Name = (name != null) ? name.Value : "", Length = (length != null) ? length.Value : "" };
    
    foreach (var node in q)
    {
        Console.WriteLine("Name={0}, Length={1}", node .Name, node .Length);
    }
