    [HttpPost]
    public async Task<ActionResult<ServiceResult>> SendEmail([FromForm]SendEmailModel model)
    {
        model.To = Regex.Replace(model.To.FirstOrDefault(), "\"", string.Empty)
                .Split(",", StringSplitOptions.None);
        //now you can loop through model.To as a string array
        foreach (string toEmail in model.To)
        {
                // Your logic here
        }
        ...
    }
