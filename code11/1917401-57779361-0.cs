        PropertySet psPropset = new PropertySet(BasePropertySet.IdOnly);
        psPropset.Add(ItemSchema.MimeContent);
        psPropset.Add(ItemSchema.Subject);
        psPropset.Add(EmailMessageSchema.Sender);
        OriginalEmail.Load(psPropset);
     
 
 
