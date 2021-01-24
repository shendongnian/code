    public Task<PaymentIntent>CreatePlatformHoldAsync(long amountInCents, string customerId,
        string paymentMethodId, string idem = null, string currency = DEFAULT_TRANSACTION_CURRENCY)
    {
        var paymentIntentService = new PaymentIntentService();
        var options = new PaymentIntentCreateOptions
        {
            Amount = amountInCents,
            Currency = currency,
            //ReceiptEmail = "", // TODO Obtain this from the Logged in user
            PaymentMethodTypes = new List<string> { "card" },
            CustomerId = customerId,
            PaymentMethodId = paymentMethodId,
            CaptureMethod = "manual",
        };
        var requestOptions = new RequestOptions { IdempotencyKey = idem };
        return paymentIntentService.CreateAsync(options, requestOptions);
    }
    /// <summary>
    /// Confirm a payment intent, on the platform or sellerAccount
    /// </summary>
    /// <param name="sellerStripeAccountId">optional, omit for the platform confirm</param>
    public Task<PaymentIntent> ConfirmPaymentAsync(string paymentIntentId,
        string sellerStripeAccountId = null)
    {
        var paymentIntentService = new PaymentIntentService();
        var paymentIntentConfirmOptions = new PaymentIntentConfirmOptions();
        var options = new RequestOptions
        {
            StripeAccount = sellerStripeAccountId
        };
        return paymentIntentService.ConfirmAsync(paymentIntentId, 
            paymentIntentConfirmOptions, options);
    }
