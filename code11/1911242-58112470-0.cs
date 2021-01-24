`
public class IncomingBehavior :  Behavior<IIncomingLogicalMessageContext>
    {
        public override Task Invoke(IIncomingLogicalMessageContext context, Func<Task> next)
        {            
            context.StoreHeaderValueToPipelineContext(KnownHeader.MyHeader);
            NLog.MappedDiagnosticsLogicalContext.Clear();
            context.StoreHeaderToNLogContext(KnownHeader.MyHeader); 
            return next();
        }
    }
public class OutgoingBehavior : Behavior<IOutgoingLogicalMessageContext>
    {
        public override Task Invoke(IOutgoingLogicalMessageContext context, Func<Task> next)
        {
            context.StorePipelineContextToOutgoingMessageHeader(KnownHeader.MyHeader); 
            return next();
        }
    }
public static class IMessageProcessingExtensions
    {
        public static IMessageProcessingContext StoreHeaderValueToPipelineContext(this IMessageProcessingContext context,
            string headerName)
        {
            if (context.MessageHeaders.TryGetValue(headerName, out string headerValue))
            {
                context.Extensions.Set(headerName, headerValue);
            }
            return context;
        }
        public static IOutgoingLogicalMessageContext StorePipelineContextToOutgoingMessageHeader
        (this IOutgoingLogicalMessageContext context,
            string headerName)
        {
            if (context.Extensions.TryGet(headerName, out string headerValue))
            {
                context.Headers[headerName] = headerValue;
            }
            return context;
        }
        public static IMessageProcessingContext StoreHeaderToNLogContext(this IMessageProcessingContext context,
            string headerName)
        {
            if (context.MessageHeaders.TryGetValue(headerName, out string headerValue))
            {
                NLog.MappedDiagnosticsLogicalContext.Set(headerName, headerValue);
            }
            return context;
        }
    }
`
 
