    public ServiceException(string key, string message, Exception innerException)
                :base(message, new innerException)
            {
                Errors = new Dictionary<string, string>(); 
                Errors.Add(key, message);
            }
