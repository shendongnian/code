    string xml = 
    "<root>
        <photo>/filesphoto.jpg</photo>
        <photo:mtime>12</photo:mtime>
        <text>some text</text>
    </root>";
    XElement x = parseWithNamespaces(xml, new string[] { "photo" });
    foreach (XElement e in x.Elements()) { 
        Console.WriteLine("{0} = {1}", e.Name, e.Value); 
    }
    Console.WriteLine(x.Element("{photo}mtime").Value);
