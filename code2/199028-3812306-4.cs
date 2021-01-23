    using System.Linq;
    var doc = new System.Xml.XmlDocument();
    doc.LoadXml(xml);
    var nodes = doc.SelectNodes("Root/Child");
    var arr = nodes
        .OfType<XmlNode>()
        .ToArray();
    var result = arr
        .Select(n =>
            new
            {
                ClNo = String.Format("A{0}", Array.IndexOf(arr, n) +1),
                Val1 = n.Attributes["val1"].Value,
                Val2 = n.Attributes["val2"].Value,
            });
    foreach (var i in result)
    {
        var index = i.ClNo;
    	var column1 = i.Column1;
    	var column2 = i.Column2;
        // use variables to add an item to ListView
    }
