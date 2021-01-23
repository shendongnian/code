        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {      
            foreach (ChannelDispatcher chDisp in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher epDisp in chDisp.Endpoints)
                {                   
                    foreach (DispatchOperation op in epDisp.DispatchRuntime.Operations)
                        op.ParameterInspectors.Add(new DataSetParameterInspector());
                }
            }
     
        }
