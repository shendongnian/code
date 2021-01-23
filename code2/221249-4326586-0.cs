    using (FileStream lStream = new FileStream("ConfigurationSettings.xml", FileMode.Open, FileAccess.Read))
    {
         XElement lRoot = XElement.Load(lReader)
         string userLogin = "user1";
         XElement user = lRoot.Element("UserSettings").Elements("user").Where(x => x.Attribute("Key").Value == userLogin).FirstOrDefault();
          if (user != null)
          {
              // returns red
              string color = user.Element("layout").Attribute("color").Value;
              
              // returns 5
              string fontSize = user.Element("layout").Attribute("fontsize").Value;
          }
                
    }
