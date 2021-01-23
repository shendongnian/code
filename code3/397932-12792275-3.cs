    using System;
    using System.Linq;
    using System.Activities;
    using System.Activities.Statements;
    
    namespace SampleWorkflowAppOne
    {
    	using Microsoft.Practices.Prism.Events;
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var purchaseOrderValidationWorkflow = new PurchaseOrderValidationWorkflow();
    			var eventAggregator = new EventAggregator();
    			var wfInvoker = new WorkflowInvoker(purchaseOrderValidationWorkflow);
    			wfInvoker.Extensions.Add(eventAggregator);
    			wfInvoker.Invoke();
    		}
    	}
    }
