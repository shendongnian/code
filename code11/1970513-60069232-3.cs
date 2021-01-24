    public static void SignalCustomerChanged(string customerId)
    {
        if (CustomerChangeTokens.TryRemove(customerId, out var changeToken))
        {
            changeToken.SignalChanged();
        }
    }
