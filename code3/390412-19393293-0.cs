        public void IsValid()
        {
            RegisterConfiguration();
            var endPoints = Host.Description.Endpoints;
            if (!endPoints.HasElements())
            {
                throw new NullReferenceException("endpoints (WCF Service).");
            }
            foreach (var item in endPoints)
            {
                var service = new ChannelFactory<ITcoService>(item.Binding, item.Address);
                try
                {
                    var client = (IClientChannel)service.CreateChannel();
                    try
                    {
                        client.Open(TimeSpan.FromSeconds(2));
                        throw new InvalidOperationException(
                            string.Format(
                                "A registration already exists for URI: \"{0}\" (WCF Service is already open in some IChannelListener).",
                                item.Address));
                    }
                    catch (Exception ex)
                    {
                        if (ex is System.ServiceModel.CommunicationObjectFaultedException ||
                            ex is System.ServiceModel.EndpointNotFoundException)
                        {
                            Debug.WriteLine(ex.DumpObject());
                        }
                        else
                        {
                            throw;
                        }
                    }
                    finally
                    {
                        new Action(client.Dispose).InvokeSafe();
                    }
                }
                finally
                {
                    new Action(service.Close).InvokeSafe();
                }
            }
        }
