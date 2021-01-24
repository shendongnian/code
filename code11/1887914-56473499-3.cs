    [Route("tenants/{tenantId:long}/subscriptions/{subscriptionId:long}/invoices")]
    [HttpGet]
    public IEnumerable<InvoiceViewModel> Get([FromQuery]IEnumerable<long> invoiceIDs)
    {
    
    }
