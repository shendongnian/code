    public static void SetDataContractSerializerBehavior(ContractDescription contractDescription)
    {
        foreach (OperationDescription operation in contractDescription.Operations)
        {
             DataContractSerializerOperationBehavior dcsob = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
             if (dcsob != null)
             {
                operation.Behaviors.Remove(dcsob);
             }
             operation.Behaviors.Add(new     ReferencePreservingDataContractSerializerOperationBehavior(operation));
        }
    }
