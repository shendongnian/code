    ExchangeService exchangeService = ...
    EmailMessage mailMessage = ...
    
    var propertySet = new PropertySet(BasePropertySet.FirstClassProperties, ItemSchema.MimeContent, EmailMessageSchema.IsRead);
    
    exchangeService.LoadPropertiesForItems(mailMessage, propertySet);
    
    File.WriteBytes("filename.eml", mailMessage.MimeContent.Content);
