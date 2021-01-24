    public async Task PublishAsync(...)
    {
        await _eventGridClient.PublishEventsAsync(_eventGridTopicHostName, ...)
            .ConfigureAwait(false);
    }
