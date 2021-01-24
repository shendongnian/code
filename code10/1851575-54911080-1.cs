    //... omitted for brevity
    
    if (!MyService.IsConnected) {
        var info = new ResultInformation() { 
            ResultCode = 2000056, 
            Message = "My service is not reachable" 
        };
        context.Result = new ObjectResult(info) {
            StatusCode = 504
        };
    }
    
    //... omitted for brevity
    
