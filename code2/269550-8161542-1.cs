	public class MyAttribute : Attribute, IServiceBehavior, IOperationBehavior
	{
		#region IServiceBehavior Members
		public void ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase host)
		{
			foreach (ServiceEndpoint endpoint in host.Description.Endpoints)
			{
				foreach (var operation in endpoint.Contract.Operations)
				{
					operation.Behaviors.Add(this);
				}
			}
		}
		...
		#endregion
		#region IOperationBehavior Members
		public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
		{
			dispatchOperation.Invoker = new OperationInvoker(dispatchOperation.Invoker);
		}
		...
		#endregion
	}
