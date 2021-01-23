    // get the list of available google docs
            RequestSettings settings = new RequestSettings(kApplicationName);
            settings.AutoPaging = false;
            if (settings != null)
            {
                DocumentsRequest request = new DocumentsRequest(settings);
                request.Service.RequestFactory = GetGoogleOAuthFactory();
                Feed<Document> feed = request.GetEverything();
                List<Document> all = new List<Document>(feed.Entries);
                // loop through the documents and add them from google
                foreach (Document entry in all)
                {
                    // first check to see whether the document has already been selected or not
                    bool found = model.Docs.Any(d => d.GoogleDocID == entry.ResourceId);
                    if (!found)
                    {
                        GoogleDocItem doc = new GoogleDocItem();
                        doc.GoogleDocID = entry.ResourceId;
                        doc.ETag = entry.ETag;
                        doc.Url = entry.DocumentEntry.AlternateUri.Content;
                        doc.Title = entry.Title;
                        doc.DocType = entry.Type.ToString();
                        doc.DocTypeID = entry.Type;
                        if (entry.ParentFolders.Count == 0)
                        {
                            // add the doc to the list
                            model.AvailableDocs.Add(doc);
                            // if the doc is a folder, get the children
                            if (doc.DocTypeID == Document.DocumentType.Folder)
                            {
                                AddAllChildrenToFolder(ref doc, entry, all);
                            }
                        }
                    }
                }
            }
    public GOAuthRequestFactory GetGoogleOAuthFactory()
        {
            // build the base parameters
            OAuthParameters parameters = new OAuthParameters
            {
                ConsumerKey = kConsumerKey,
                ConsumerSecret = kConsumerSecret
            };
            // check to see if we have saved tokens and set
            var tokens = (from a in context.GO_GoogleAuthorizeTokens select a);
            if (tokens.Count() > 0)
            {
                GO_GoogleAuthorizeToken token = tokens.First();
                parameters.Token = token.Token;
                parameters.TokenSecret = token.TokenSecret;
            }
            // now build the factory
            return new GOAuthRequestFactory("anyname", kApplicationName, parameters);
        }
