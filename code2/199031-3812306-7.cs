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
    ListView list = new ListView();
    ListViewItem[] items = result
        .Select(r => new ListViewItem(r.ClNo, r.Val1, r.Val2)
        .ToArray();
    list.Items.AddRange(items);
