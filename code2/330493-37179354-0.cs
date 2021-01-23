    this.ConnectionFactory.UserName = this.Username;
    this.ConnectionFactory.Password = this.Password;
    
    this.ConnectionFactory.BrokerUri = new System.Uri(this.Uri);
    
    using (IConnection conn = this.ConnectionFactory.CreateConnection())
    {
    using (ISession session = conn.CreateSession())
    {
        IObjectMessage objMessage = session.CreateObjectMessage(message);
        using (IMessageProducer producer = session.CreateProducer())
                {
                        NmsDestinationAccessor destinationResolver = new NmsDestinationAccessor();
                        IDestination destination = destinationResolver.ResolveDestinationName(session, this.Queue);
                        producer.Send(destination, objMessage);
                }
        }
    }
