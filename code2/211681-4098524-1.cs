    Dim service As New ExchangeService(ExchangeVersion.Exchange2007_SP1)
    service.Url = New Uri(ConfigurationManager.AppSettings("URL"))
    service.Credentials = New NetworkCredential(ConfigurationManager.AppSettings("Username"), ConfigurationManager.AppSettings("Password"), ConfigurationManager.AppSettings("Domain"))
            
    Dim myProp As New ExtendedPropertyDefinition(
       DefaultExtendedPropertySet.Common,
       34080,
       MapiPropertyType.Binary
    )
    
    Dim foundItem As Item = service.FindItems(WellKnownFolderName.Inbox, New ItemView(10))(0)
    
    Dim otherMessage As EmailMessage = EmailMessage.Bind(service, foundItem.Id, New PropertySet(myProp))
    Dim bytes As Byte() = DirectCast(otherMessage(myProp), Byte())
