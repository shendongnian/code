    public async Task<bool> CheckBoth()
    {
        var client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        const string grafanaHealthUrl = "https://myGrafanaURL/api/health";
        const string influxPingUrl = "https://myInfluxURL/ping";
        var (grafanaOK, grafanaError) = await CheckAsync(client, grafanaHealthUrl,
                                                         HttpStatusCode.OK, "Grafana error");
        var (influxOK, influxError) = await CheckAsync(client, influxPingUrl, 
                                                       HttpStatusCode.NoContent,"InfluxDB error");
        if (!influxOK || !grafanaOK)
        {
                    //Do something with the errors
                    return false;
        }
        return true;
    }
    public async Task<(bool ok, string result)> CheckAsync(HttpClient client,
                                                           string healthUrl, 
                                                           HttpStatusCode expected,
                                                           string errorMessage)
    {
        try
        {
            var status = await client.GetAsync(healthUrl);
            if (status.StatusCode != expected)
            {
                //Failure message, get it and log it
                var statusBody = await status.Content.ReadAsStringAsync();
                //Possibly log it ....
                return (ok: false, result: $"{errorMessage}: {statusBody}");
            }
        }
        catch (TaskCanceledException)
        {
            return (ok: false, result: $"{errorMessage}: Timeout");
        }
        return (ok: true, "");
    }
