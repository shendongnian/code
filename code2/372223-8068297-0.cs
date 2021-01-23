            Uri connecturi = new Uri("activemq:tcp://model.net:61616");
            IConnectionFactory factory = new NMSConnectionFactory(connecturi);
            List<ModelBuilderBase> result = new List<ModelBuilderBase>();
            using (IConnection connection = factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                
                IDestination destination = SessionUtil.GetDestination(session, "queue://cidModelbuilderQ");
                using (IMessageConsumer consumer = session.CreateConsumer(destination))
                {
                    connection.Start();
                    var q = session.GetQueue("cidModelbuilderQ");
                    var b = session.CreateBrowser(q);
                    var msgs = b.GetEnumerator();
                    while (msgs.MoveNext())
                    {
                        ITextMessage message = msgs.Current as ITextMessage;
                        if (message.Properties[MANDATOR] == null || message.Properties[REFCODE] == null)
                            continue;
                        var mandator = message.Properties[MANDATOR].ToString();
                        var refCode = message.Properties[REFCODE].ToString();
                        result.Add(ModelBuilderFactory.Instance.GetInstance(refCode, mandator));
                    }
                }
            }
