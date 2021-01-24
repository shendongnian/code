    var info = new ResultInformation() { ResultCode = 0, Message = "message here" };
    context.Result = new ObjectResult(info) {
        StatusCode = 504
    };
    
