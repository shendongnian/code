            switch (className)
            {
                case "Customer":
                    ExecuteRestMethod<Customer>()
                    break;
                case "CustomerStatus":
                    ExecuteRestMethod<CustomerStatus>();
                    break;
            }
    public void ExecuteRestMethod<T>()
    {
                    if (_settings.Request.Method == Method.GET)
                        _settings.Response = _settings.RestClient.Execute<T>(_settings.Request);
                    else
                        _settings.Response = _settings.RestClient.ExecuteAsyncRequest<T>(_settings.Request).GetAwaiter().GetResult();
    }
