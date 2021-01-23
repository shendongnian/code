    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
    service.Url = new Uri(ConfigurationManager.AppSettings["URL"]);
    
    service.Credentials = new NetworkCredential(
        ConfigurationManager.AppSettings["Username"], 
        ConfigurationManager.AppSettings["Password"], 
        ConfigurationManager.AppSettings["Domain"]
        );
              
    Item foundItem = service.FindItems(WellKnownFolderName.Inbox, new ItemView(10)).Items[0];
            
    ExtendedPropertyDefinition myProp = new ExtendedPropertyDefinition(
        DefaultExtendedPropertySet.Common,
        0x00008520,
        MapiPropertyType.Binary
    );
            
    EmailMessage otherMessage = EmailMessage.Bind(service, foundItem.Id, new PropertySet(myProp));
    byte[] bytes = (byte[])otherMessage[myProp];   
