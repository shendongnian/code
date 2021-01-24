    string s = "{\"premiuminfo\":{\"country\":{\"value\":\"country1\"},\"town\":{\"value\":\"town1\"},\"given_name\":{\"value\":\"given_name1\"},\"postal_code\":{\"value\":\"postal_code1\"},\"family_name\":{\"value\":\"family_name1\"},\"houseno_or_housename\":{\"value\":\"houseno_or_housename1\"}}}";
    //s = jwtData.ContainsKey("claims");
    try
    {
        JsonElement o = JsonSerializer.Deserialize<JsonElement>(s);
        if (o.TryGetProperty("premiuminfo", out var premiuminfo))
        {
            if (!premiuminfo.TryGetProperty("name", out var _) && (!premiuminfo.TryGetProperty("given_name", out var _) || !premiuminfo.TryGetProperty("family_name", out var _)))
            {
                processingResult = new ProcessingResultObject { ErrorResult = new ErrorResult { error = ErrorTypes.invalid_request.ToString(), error_description = "name or given_name, family_name is missing in claims" }, StatusCode = 400 };
            }
            else if (premiuminfo.TryGetProperty("name", out var _) && (premiuminfo.TryGetProperty("given_name", out var _) || !premiuminfo.TryGetProperty("family_name", out var _)))
            {
                processingResult = new ProcessingResultObject { ErrorResult = new ErrorResult { error = ErrorTypes.invalid_request.ToString(), error_description = "name and (given_name, family_name) both exists in claims" }, StatusCode = 400 };
            }
            else if (!premiuminfo.TryGetProperty("address", out var _) && (!premiuminfo.TryGetProperty("houseno_or_housename", out var _) || !premiuminfo.TryGetProperty("postal_code", out var _)))
            {
                processingResult = new ProcessingResultObject { ErrorResult = new ErrorResult { error = ErrorTypes.invalid_request.ToString(), error_description = "address is missing in claims" }, StatusCode = 400 };
            }
            else if (premiuminfo.TryGetProperty("address", out var _) && (premiuminfo.TryGetProperty("houseno_or_housename", out var _) || premiuminfo.TryGetProperty("postal_code", out var _)))
            {
                processingResult = new ProcessingResultObject { ErrorResult = new ErrorResult { error = ErrorTypes.invalid_request.ToString(), error_description = "address and (houseno_or_housename, postal_code) both exists in claims" }, StatusCode = 400 };
            }
            else
            {
                processingResult.Result = true;
            }
        }
        else
        {
            processingResult = new ProcessingResultObject { ErrorResult = new ErrorResult { error = ErrorTypes.invalid_request.ToString(), error_description = "premiuminfo are not found in claims" }, StatusCode = 400 };
        }
    }
    catch (Exception ex)
    {
        processingResult = new ProcessingResultObject { ErrorResult = new ErrorResult { error = ErrorTypes.invalid_request.ToString(), error_description = "premiuminfo are not found in claims. ex" }, StatusCode = 400 };
    }
