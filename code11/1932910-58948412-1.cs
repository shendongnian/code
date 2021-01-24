    var payload = new LineProtocolPayload();
    const string measurement = "logs";
    var memoryLoad = new LineProtocolPoint(measurement,
         new Dictionary<string, object>
         {
             {"message", e.Exception?.Message,},
         },
         new Dictionary<string, string>
         {
             {"host", Environment.GetEnvironmentVariable("COMPUTERNAME")},
             {"app", "{my app name}"},
         },
         DateTime.UtcNow);
    payload.Add(memoryLoad);       
    var influxResult = Client.WriteAsync(payload, ct).Result;
