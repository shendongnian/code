    var orderTask = ordersRepository.Find(orderId);  // Takes 1 second
    var invoicesTask = invoiceRepository.FindBy(orderId); // Takes 2 seconds
    var deliveriesTask = deliveryRepository.FindBy(orderId); // Takes 3 seconds
    await Task.WhenAll(orderTask, invoicesTask, deliveriesTask); 
    var order = await orderTask;
    var invoices = await invoicesTask;
    var deliveries = await deliveriesTask;
