    var factory = new ChannelFactory<IInterface>(...);
    foreach (OperationDescription op in factory.Endpoint.Contract.Operations)
        {
            var dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>();
            if (dataContractBehavior != null)
            {
                dataContractBehavior.MaxItemsInObjectGraph = int.MaxValue;
            }
        }
