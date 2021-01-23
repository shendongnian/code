    ICommunicationObject obj = (ICommunicationObject)callback;
                    obj.Closed += new EventHandler((a, b) => 
                    {
                        if (list.Exists(cli => cli.CallbackService == (ITecnobelRemoteServiceCallback)a))
                        {
                            var query = (from cc in list where cc.CallbackService == (ITecnobelRemoteServiceCallback)a select cc).ToList();
                            query.ForEach(
                                delegate (Client ccc)
                                {
                                    ccc.CallbackService = null;
                                });
                        }
                    });
