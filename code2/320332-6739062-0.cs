    public ObservableCollection<Results> result = new ObservableCollection<Results>();
                    
    XDocument xmldoc = XDocument.Parse(e.Result.ToString());
    var data = from c in xmldoc.Descendants("ResourceSets").Descendants("ResourceSet").Descendants("Resources").Descendants("Location")
        select new Results{
        Place = c.Element("Name").Value;
        Lat = c.Element("Point").Element("Latitude").Value;
        Long = c.Element("Point").Element("Longitude").Value;
        };
        foreach (Results obj in data) 
        {
            result.Add(obj);
        }
