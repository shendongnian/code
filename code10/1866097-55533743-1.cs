    public void UpdateInvoicePaymentStatus(InvoiceModel invoice)
    {
        _orderBusinessLogic.IsModuleEnabled()?.UpdateOrderStatus(invoice.OrderId);
       //just example stuff
       int? orderId = _orderBusinessLogic.IsModuleEnabled()?.GetOrderIdForInvoiceId(invoice.InvoiceId);
    }
