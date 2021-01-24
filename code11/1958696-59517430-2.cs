    var invoiceOptions = new InvoiceCreateOptions
    {
        CustomerId = ... customer id,
        AutoAdvance = false,
        SubscriptionId = ... subscriptionId,
        Billing = Billing.ChargeAutomatically
    };
    var diffInvoice = await _stripeInvoiceService.CreateAsync(invoiceOptions);
    // There's an alternative using Invoice Finalization, but this seems quicker
    await _stripeInvoiceService.PayAsync(diffInvoice.Id, new InvoicePayOptions());
