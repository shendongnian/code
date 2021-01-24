            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
            service.Credentials = new WebCredentials("USERNAME", "PASSWORD");
            service.AutodiscoverUrl("MAILID");
            Mailbox mb = new Mailbox("MAILID");
            FolderId fid = new FolderId(WellKnownFolderName.Inbox, mb);
            Folder inbox = Folder.Bind(service, fid);
            ItemView view = new ItemView(1000);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly, ItemSchema.Subject, ItemSchema.DateTimeSent);
            PropertySet PropSet = new PropertySet();
            PropSet.Add(ItemSchema.Subject);
            PropSet.Add(ItemSchema.Body);
            PropSet.Add(ItemSchema.DateTimeReceived);
            PropSet.Add(EmailMessageSchema.From);
            PropSet.Add(EmailMessageSchema.Attachments);
            PropSet.Add(EmailMessageSchema.HasAttachments);
            PropSet.RequestedBodyType = BodyType.Text;
            //PropSet.Add(ItemSchema.MimeContent); - Only for saving email as File
            // Item searches do not support Deep traversal.
            view.Traversal = ItemTraversal.Shallow;
            // Sorting
            view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending);
            SearchFilter.SearchFilterCollection searchFilterCollection = new SearchFilter.SearchFilterCollection(LogicalOperator.And);
            SearchFilter sfSentDateTime = new SearchFilter.IsGreaterThan(ItemSchema.DateTimeSent, Convert.ToDateTime("06/25/2019 4:00"));
            searchFilterCollection.Add(sfSentDateTime);
            SearchFilter sfMarkedAsUnread = new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false);
            searchFilterCollection.Add(sfMarkedAsUnread);
            FindItemsResults<Item> items = inbox.FindItems(searchFilterCollection, view);
            string sXml = string.Empty;
            if (items != null && items.Any())
            {
                StringBuilder sb = new StringBuilder();
                foreach (Item item in items)
                {
                    item.Load(PropSet);
                    EmailMessage email = (EmailMessage)item;
                    if (email.Attachments.Count > 0)
                    {
                        AttachmentCollection attachmentsCol = email.Attachments;
                        for (int i = 0; i < email.Attachments.Count; i++)
                        {
                            FileAttachment oAttachement = (FileAttachment)email.Attachments[i];
                            // Saving the attachment
                            oAttachement.Load("C:\\Temp\\" + oAttachement.Name);
                        }
                    }
                }
                sXml = string.Format("<root>{0}</root>", sb.ToString());
            }
       
            }
