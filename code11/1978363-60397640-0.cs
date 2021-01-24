    public async Task<IActionResult> Get(...)
    {
        _logger.LogInformation("Action Get is running");
    
        if (_logger.IsEnabled(Serilog.Events.LogEventLevel.Debug))
        {
            _logger.LogDebug("-- debug log. deserialized payload: {Payload}", DeserializePayload(message));
        }
        // ...
    }
