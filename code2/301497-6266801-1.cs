     XmlTextReader reader = new XmlTextReader("c:/countryCodes.xml");
          List<Country> countriesList = new List<Country>();
          Country country=new Country();
          bool first = false;
          while (reader.Read())
          {
            switch (reader.NodeType)
            {
              case XmlNodeType.Element: // The node is an element.
                if (reader.Name == "ISO_3166-1_Entry") country = new Country();
                break;
              case XmlNodeType.Text: //Display the text in each element.
                if (first == false)
                {
                  first = true;
                  country.Name = reader.Value;
                }
                else
                {
                  country.Code = reader.Value;
                  countriesList.Add(country);
                  first = false;
                }                       
                break;          
            }        
          }
          return countriesList;  
 
