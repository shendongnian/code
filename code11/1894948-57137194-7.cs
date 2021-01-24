    public Task<PaymentIntent> CreateDestinationChargeAsync(long amountInCents, long applicationFeeInCents, 
        string paymentMethodId, string destinationAccountId, string idem = null, 
        string currency = DEFAULT_TRANSACTION_CURRENCY)
    {
            
        var paymentIntentService = new PaymentIntentService();
        var options = new PaymentIntentCreateOptions
        {
            Amount = amountInCents,
            Currency = currency,
            ApplicationFeeAmount = applicationFeeInCents,
            //ReceiptEmail = "", // TODO Obtain this from the Logged in user
            PaymentMethodTypes = new List<string> { "card" },
            PaymentMethodId = paymentMethodId,
        };
        var requestOptions = new RequestOptions
        {
            IdempotencyKey = idem,
            StripeAccount = destinationAccountId
        };
        return paymentIntentService.CreateAsync(options, requestOptions);
    }
