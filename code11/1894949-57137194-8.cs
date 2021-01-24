    public async Task<Customer> CreateCustomerAsync(string email, string sourceToken)
    {
        var options = new CustomerCreateOptions
        {
            Email = email, // "paying.user@example.com",
            Source = sourceToken,
        };
        var service = new CustomerService();
        return await service.CreateAsync(options);
    }
    /// <summary>
    /// Creates a payment method for a customer on the sellers stripe account 
    /// </summary>
    /// <returns></returns>
    public async Task<PaymentMethod> CreatePaymentMethodAsync(string customerId, string paymentMethodId,
        string stripeConnectAccountId)
    {
        var paymentMethodService = new PaymentMethodService();
        var paymentMethodOptions = new PaymentMethodCreateOptions
        {
            CustomerId = customerId,
            PaymentMethodId = paymentMethodId
        };
        var requestOptions = new RequestOptions()
        {
            StripeAccount = stripeConnectAccountId
        };
        return await paymentMethodService.CreateAsync(paymentMethodOptions, requestOptions);
    }
