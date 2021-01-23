    namespace SampleWorkflowAppOne
    {
    	using System.Activities;
    	using Microsoft.Practices.Prism.Events;
    
    	public class PurchaseOrderInventoryCheckActivity : NativeActivity
    	{
    		protected override void CacheMetadata(NativeActivityMetadata metadata)
    		{
    			metadata.RequireExtension<IEventAggregator>();
    		}
    
    		protected override void Execute(NativeActivityContext context)
    		{
    			var eventAggregator = context.GetExtension<IEventAggregator>();
    			var somethingHappenedEvent = eventAggregator.GetEvent<MyActivityEvent>();
    			var myEventInfo = new MyEventInfo() { SomeNumber = 5 };
    			somethingHappenedEvent.Publish(myEventInfo);
    		}
    	}
    
    	public class MyActivityEvent : CompositePresentationEvent<MyEventInfo>
    	{
    	}
    
    	public class MyEventInfo
    	{
    		public int SomeNumber { get; set; }
    	}
    }
