    using (ClientContext clientContext = TokenHelper.CreateRemoteEventReceiverClientContext(properties))
                {
                    if (clientContext != null)
                    {
                        var user = clientContext.Web.CurrentUser;
                        clientContext.Load(user);
                        clientContext.ExecuteQuery();
