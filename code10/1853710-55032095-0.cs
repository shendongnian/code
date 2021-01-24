    public OkObjectResult response(String output)
    {
        WebhookResponse googleResponse = new WebhookResponse();
        googleResponse.FulfillmentText = output;
    
        return new OkObjectResult(googleResponse);//This is returned from the main function
    }
