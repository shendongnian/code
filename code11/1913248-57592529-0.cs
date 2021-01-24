    } catch (TaskCanceledException) {
        //Could have been caused by cancellation or timeout if you used one.
        //If that was the case, rethrow.
        //cancellationToken.ThrowIfCancellationRequested();
        //HttpClient throws TaskCanceledException when the request times out. That's dumb.
        //Throw TimeoutException instead and say how long we waited.
        string time;
        if (_httpClient.Timeout.TotalHours > 1) {
            time = $"{_httpClient.Timeout.TotalHours:N1} hours";
        } else if (_httpClient.Timeout.TotalMinutes > 1) {
            time = $"{_httpClient.Timeout.TotalMinutes:N1} minutes";
        } else if (_httpClient.Timeout.TotalSeconds > 1) {
            time = $"{_httpClient.Timeout.TotalSeconds:N1} seconds";
        } else {
            time = $"{_httpClient.Timeout.TotalMilliseconds:N0} milliseconds";
        }
        throw new TimeoutException($"No response after waiting {time}.");
    }
