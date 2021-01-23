  public class OrderHandler
  {          
    public void HandleOrder(Order order)
    {
	  var context = new PaymentGuardContext();
  
	  var state = new State<Order, OrderState>(order, a => a.State)
				.Define(b =>
				{
					b.From(OrderState.Initial).To(OrderState.Paid)
					  .Changing(OnTransitioningStateFromInitialToPaidHandler)
					  .Changed(OnTransitionedStateFromInitialToPaidHandler);
					
					b.From(OrderState.Paid).To(OrderState.Processed);
					b.From(OrderState.Processed).To(OrderState.Delivered);
					b.OnEnter(OrderState.Paid, Guards<OrderState>.From(context,
						ValidateRequest,
						PayToPaymentGateway, 
						PersistOrderToRepository
					));
					b.DisableSameStateTransitionFor(OrderState.Paid);
					
				});
        var hasChangedState = state.ChangeTo(OrderState.Paid);
        
        //Assert.Equal(OrderState.Paid, order.State);
	}
  
    public void HandleOrderUsingExtensionAndTriggers(Order order)
    {
          var context = new PaymentGuardContext();
          var triggerToOrderStatePaid = "triggerToOrderStatePaid";
      
          var state = order.State.AsState(b =>
                    {
                        b.From(OrderState.Initial).To(OrderState.Paid)
                          .Changing(OnTransitioningStateFromInitialToPaidHandler);
                      
                        b.TriggerTo(OrderState.Paid, triggerToOrderStatePaid);
                    });
  
        StateMachineManager.Trigger(triggerToOrderStatePaid);
        
        //Assert.Equal(OrderState.Paid, order.State);
    }	
	
	private class PaymentGuardContext : GuardContext<OrderState>
    {
    }
    
    private void OnTransitioningStateFromInitialToPaidHandler(IState<OrderState> state, OrderState next)
    {   
        //throwing exception in Changing handler prevents the state change
        //throw new Exception();        
    }
        
    private void OnTransitionedStateFromInitialToPaidHandler(OrderState previous, IState<OrderState> state)
    {        
    }
    private void ValidateRequest(PaymentGuardContext context)
    {    
        context.Continue = true;
    }
    private void PayToPaymentGateway(PaymentGuardContext context)
    {
        context.Continue = true;
    }
    private void PersistOrderToRepository(PaymentGuardContext context)
    {
        context.Continue = true;
    }
	public class Order
	{
	  public int Id { get; set; }
	  public OrderState State { get; set; }
	}
        
	public enum OrderState
	{
	  Initial,
	  Paid,
	  Processing,
	  Processed,
	  Delivered
	}
  
  }
