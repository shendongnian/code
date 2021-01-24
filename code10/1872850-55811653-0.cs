    [HttpGet]
    [Route("api/v1/cards")]
    public IActionResult Cards(inputParameters,selector,filtering)
    {
        var result = new Dictionary<string, object>();
        result["variable1"] = "value1";
        if (something == true)
            result["variable2"] = 7;
        return OK(result);
    }
