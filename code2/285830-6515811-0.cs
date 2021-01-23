    public bool UploadAttachment()
        {
            try
            {
                //AsyncSendData data = new AsyncSendData();
                
                string parentUrl = Cabinets["Cabinet1"].ToString();
                string parentID = parentUrl.Split('/')[7];
                AtomEntry entry = new AtomEntry();
                entry.Title.Text = "abc.jpg";
                
                AtomCategory cat = new AtomCategory();
                cat.Term = ATTACHMENT_TERM;
                cat.Label = "attachment";
                cat.Scheme = KIND_SCHEME;
                entry.Categories.Add(cat);
                AtomLink link = new AtomLink();
                link.Rel = PARENT_REL;
                link.HRef = parentUrl;
                entry.Links.Add(link);
                AtomContent content = new AtomContent();
                FileInfo info = new FileInfo("C:\\Bluehills.txt");
                FileStream stream = info.Open(FileMode.Open,FileAccess.ReadWrite,FileShare.ReadWrite);
               
                this.setUserCredentials(userName, password);
                Uri postUri = new Uri(makeFeedUri("content"));
                entry.Source = new AtomSource();
                //this.EntrySend(postUri, entry, GDataRequestType.Insert);
                // Send the request and receive the response:
                AtomEntry insertedEntry = this.Insert(postUri, stream, (string)DocumentTypes["TXT"], "bluehills");
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
