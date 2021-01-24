    [Route("{providerName}/CalendarAvailability")]
    [HttpGet]
    public Task<IActionResult> GetCalendarAvailability(CalendarAvailabilityRequest request)
    {
        var validationResult = new CalendarAvailabilityRequestValidator().Validate(request);
        if (!validationResult.IsValid)
        {
            Log.Warning(validationResult.Errors.ToString());
            return BadRequest(validationResult.Errors);
        }
        var statDate = DateTime.ParseExact(request.StartDate, "yyyy-mm-dd", CultureInfo.InvariantCulture);
        //TODO: calendar availability logic
        return OK(); 
    }
