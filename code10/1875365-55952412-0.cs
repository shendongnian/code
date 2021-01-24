    public class ProtobufBehavior : WebHttpBehavior
        {
            protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
            {
                return new ProtobufDispatchFormatter(operationDescription);
            }
    
            protected override IDispatchMessageFormatter GetReplyDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
            {
                return new ProtobufDispatchFormatter(operationDescription);
            }
        }
