    public void Invoke() 
    {
          InvokeRequest invokeRequest = new InvokeRequest
                                           {
                                                FunctionName = FunctionName,
                                                Payload = Payload
                                           };
       Client.InvokeAsync(invokeRequest, responseObject => 
       {
            if (responseObject.Exception == null) 
            {
                 Debug.Log("LAMBDA SUCCESS: " + Encoding.ASCII.GetString(responseObject.Response.Payload.ToArray()));
                 // Call function on success and pass in the returned value
            }
            else 
            {
                Debug.Log("LAMBDA ERR: " + responseObject.Exception);
                 // Call function on failure and pass exception data
            }
       });
    }
