    public async Task Invoke() {
        InvokeRequest invokeRequest = new InvokeRequest() {
        FunctionName = FunctionName,
        Payload = Payload
        };
    
       await Client.InvokeAsync(invokeRequest, responseObject => {
            if (responseObject.Exception == null) {
                Debug.Log("LAMBDA SUCCESS: " + Encoding.ASCII.GetString(responseObject.Response.Payload.ToArray()));
            } else {
                Debug.Log("LAMBDA ERR: " + responseObject.Exception);
            }
        });
    }
