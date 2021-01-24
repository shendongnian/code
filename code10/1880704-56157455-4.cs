    [Authorize(Policy = "ValidateCertificate")]
    public HttpResponseMessage TestAuth()
    {
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            ReasonPhrase = "In Test method without any authorization."
        };
    }
