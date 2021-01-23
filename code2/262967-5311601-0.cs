    public class MyHandler : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members
    
        public object Create(object parent, object configContext, XmlNode section)
        {
            var config = new MailConfiguration();
            foreach (XmlAttribute attribute in section.GetAttributes())
            {
                  switch (attribute.Name)
                  {
                       case "server":
                           config.Server = attribute.Value;
                           break;
                       ...
                  }
            }
            foreach (XmlNode node in section.ChildNodes)
            {
                  switch (node.Name)
                  {
                       case "server":
                           config.Server = node.Value;
                           break;
                       ...
                  }
            }
        }
        return config;
    
        #endregion
      }
    }
