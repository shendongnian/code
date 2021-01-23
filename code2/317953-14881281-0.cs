    // Simplified mail item
    public class MailItem
    {
        public string From;
        public string[] Recipients;
        public string Subject;
        public string Body;
    }
    
    public MailItem[] GetUnreadMailFromInbox()
    {
        FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(128));
        ServiceResponseCollection<GetItemResponse> items = 
            service.BindToItems(findResults.Select(item => item.Id), new PropertySet(BasePropertySet.FirstClassProperties, EmailMessageSchema.From, EmailMessageSchema.ToRecipients));
        return items.Select(item => {
            return new MailItem() {
                From = ((Microsoft.Exchange.WebServices.Data.EmailAddress)item.Item[EmailMessageSchema.From]).Address,
                Recipients = ((Microsoft.Exchange.WebServices.Data.EmailAddressCollection)item.Item[EmailMessageSchema.ToRecipients]).Select(recipient => recipient.Address).ToArray(),
                Subject = item.Item.Subject,
                Body = item.Item.Body.ToString(),
            };
        }).ToArray();
    }
