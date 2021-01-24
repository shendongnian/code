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
    public Task<PaymentIntent> ConfirmPaymentAsync(string paymentIntentId)
    {
        var paymentIntentService = new PaymentIntentService();
        var paymentIntentConfirmOptions = new PaymentIntentConfirmOptions();
        return paymentIntentService.ConfirmAsync(paymentIntentId, paymentIntentConfirmOptions);
    }
    public Task<PaymentIntent> CapturePaymentIntentAsync(string paymentIntentId, long? amountInCents)
    {
        var paymentIntentService = new PaymentIntentService();
        var captureOptions = new PaymentIntentCaptureOptions() { AmountToCapture = amountInCents };
        return paymentIntentService.CaptureAsync(paymentIntentId, captureOptions);
    }
