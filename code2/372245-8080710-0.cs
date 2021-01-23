		public class WebHttpBehaviorEx : WebHttpBehavior
		{
			protected override IDispatchMessageFormatter GetReplyDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
			{
				return new DynamicFormatter();
			}
		}
		public class DynamicFormatter : IDispatchMessageFormatter
		{
			public void DeserializeRequest(Message message, object[] parameters)
			{
				throw new NotImplementedException();
			}
			public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
			{
				return WebOperationContext.Current.CreateTextResponse((result ?? string.Empty).ToString());
			}
		}
