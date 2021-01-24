    var client = new RestClient("http://externalapi");
    var request = new RestRequest("data/save", Method.GET)
        .AddQueryParameter("param1", humidity)
        .AddQueryParameter("param2", temperature)
        .AddQueryParameter("level", level)
        .AddQueryParameter("dt_event", DataFormat.dateTime)
        .AddQueryParameter("DeviceId", data.deviceId)
        .AddQueryParameter("Apid", data.apid);
    var response = await client.ExecuteAsync(request);
    var content = response.Content; // raw content as string
