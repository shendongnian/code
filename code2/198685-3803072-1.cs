    	internal class OperationLoggerBehavior : IOperationBehavior
    	{
    		public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
    		{
    		}
    
    		public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
    		{
    		}
    
    		public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
    		{
    			dispatchOperation.ParameterInspectors.Add(new OperationLogger());
    		}
    
    		public void Validate(OperationDescription operationDescription)
    		{
    		}
    	}
    
    	internal class OperationLoggerAttribute : Attribute, IContractBehavior
    	{
    		public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    		{
    		}
    
    		public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    		{
    		}
    
    		public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
    		{
    			foreach (OperationDescription operationDescription in contractDescription.Operations)
    			{
    				if (!operationDescription.Behaviors.Contains(typeof(OperationLoggerBehavior)))
    				{
    					operationDescription.Behaviors.Add(new OperationLoggerBehavior());
    				}
    			}
    		}
    
    		public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
    		{
    		}
    	}
    
    
    	internal class OperationLogger : IParameterInspector
    	{
    		/// <summary>
    		/// Called before an operation is invoked.
    		/// </summary>
    		/// <param name="operationName"></param>
    		/// <param name="inputs"></param>
    		/// <returns></returns>
    		public object BeforeCall(string operationName, object[] inputs)
    		{
    			// Write to log		}
    
    		/// <summary>
    		/// Called after an operation has been invoked.
    		/// </summary>
    		/// <param name="operationName"></param>
    		/// <param name="outputs"></param>
    		/// <param name="returnValue"></param>
    		/// <param name="correlationState"></param>
    		public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
    		{
    			// Write to log		
    }
    		}
    	}
    }
    
    
    
    // Service contract implementation    
        	[OperationLogger]
        	[ServiceBehaviorAttribute(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
        	public partial class MyService : IMyService
        	{
        ...
        	{}
