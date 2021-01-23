    string elementToFind = "example";
    System.IO.Stream kmlFile = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("objects.kml");
    Xml.Linq.XDocument xDoc = System.Xml.Linq.XDocument.Load(kmlFile);
    string xNs = "{" + xDoc.Root.Name.Namespace.ToString + "}";
    
    var coordsStr = 
    (from f in xDoc.Descendants(xNs + "Placemark")
    where elementToFind.Contains(f.Parent.Element(xNs + "name").Value + f.Element(xNs + "name").Value)
    select f.Element(xNs + "LineString").Element(xNs + "coordinates")).FirstOrDefault;
