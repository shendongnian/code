    public async Task<PaymentIntent>CreatePlatformHoldAsync(long amountInCents, string customerId,
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
        return await paymentIntentService.CreateAsync(options, requestOptions);
    }
    public async Task<PaymentIntent> ConfirmPaymentAsync(string paymentIntentId)
    {
        var paymentIntentService = new PaymentIntentService();
        var paymentIntentConfirmOptions = new PaymentIntentConfirmOptions();
        return await paymentIntentService.ConfirmAsync(paymentIntentId, paymentIntentConfirmOptions);
    }
    public async Task<PaymentIntent> CapturePaymentIntentAsync(string paymentIntentId, long? amountInCents)
    {
        var paymentIntentService = new PaymentIntentService();
        var captureOptions = new PaymentIntentCaptureOptions() { AmountToCapture = amountInCents };
        return await paymentIntentService.CaptureAsync(paymentIntentId, captureOptions);
    }
