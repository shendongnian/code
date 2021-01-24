    class MTMainPresenter
    {
        private readonly IMTMainForm _view;
        private OrdersStatsHandler _orderStatsHandler;
    
        private void Subscribe(WebsocketClient wsc)
        {
            client.Streams.OrderStream
              .Select(ordr =>
                Observable.FromAsync(async () => {
                    HandleOrderResponse(ordr);
                }))
              .Concat() //All incoming orders are queued and that is the way I want it.
              .Subscribe();
        }
    
        private void HandleOrderResponse(OrderResponse response)
        {
            try
            {
                foreach (Order o in response.Data)
                {
                    _orderStatsHandler.HandleOrder(o);
                }
    
                var bs = _orderStatsHandler.GetBindingSource();
                _view.bSRCOrders = bs;
            }
            catch (Exception exc)
            {
                Log.Error(exc.Message);
            }
        }
    }
