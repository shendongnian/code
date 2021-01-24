    public async Task<T> TryExecuteWithCertificateValidationAsync<T>(Func<Task<T>> operation)
    {
        var service = _serviceLocator.Get<IDeviceService>();
        if (service.CertificateValidationRequired())
        {
            // My Code.
        }
        T actualResult = await operation();
        return actualResult;
    }
    var response = await ValidateCertificate
        .TryExecuteWithCertificateValidationAsync(MyMethodAsync);
