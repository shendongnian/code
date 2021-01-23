    public ActionResult OrderDetails(Guid id /*the id of the order*/)
    {
    	var orderLines = Services.GetOrderLines(id);
    
    	var model = new OrdersViewModel();
        //ideally you could get to the "owner id" of the order from the order lines itself
        //depending on how your domain model is set up
    	model.Orders = Services.GetOrders(orderLines.Order.OwnerId); 
    	model.SelectedOrderItems = orderLines;
    
    	return View("Orders", model); //render the same view as the Orders page if like
    }
