     void processXML(XElement _xml)
        {
            
            var pets = from item in
                           _xml.Elements("pet")
                       select item;
            foreach (var pet in pets)
            {
                //Pet _pet = new Pet();
                 string id = (string)pet.Element("id");
                 string breeds = (string)pet.Element("breeds").Element("breed");
                 string name = (string)pet.Element("name");
                 string animal = (string)pet.Element("animal");
                 /*string media = (string)pet.Element(ns + "media")
                                                            .Element(ns + "photos").Element(ns + "photo")
                                                            .Attribute(ns + "fpm");*/
               
                 var url = from i in pet.Descendants().Elements("photo")
                           where i.Attribute("size").Value.Equals("fpm")
                           select i.Value;
                 //Results.Items.Add(_pet);
            }
        }
