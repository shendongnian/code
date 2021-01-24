              public GMailHandler(string mailServer, int port, bool ssl, string login, string password)
              {
                      if (ssl)
                      {
                             client.Connect(mailServer, port);
                      }
                      else
                             client.Connect(mailServer, port);
                      client.Authenticate(login, password);
                      inbox = client.Inbox;
              }
 
              public IEnumerable<string> GetEmailWithSubject (string emailSubject)
              {
                      var messages = new List<string>();
 
                      inbox.Open(FolderAccess.ReadWrite);
                      var results = inbox.Search(SearchOptions.All, SearchQuery.Not(SearchQuery.Seen));
                      foreach (var uniqueId in results.UniqueIds)
                      {
                             var message = client.Inbox.GetMessage(uniqueId);
 
                             if (message.Subject.Contains(emailSubject))
                             {
                                    messages.Add(message.HtmlBody);
                             }
                                   
                             //Mark message as read
                             inbox.AddFlags(uniqueId, MessageFlags.Seen, true);
                      }
 
                      client.Disconnect(true);
                     
                      return messages;
              }
