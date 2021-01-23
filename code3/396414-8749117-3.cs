    var devices = document["devices"].AsBsonArray;
    if (devices.Count > 0)
    {
        var deviceinfo = devices[0].AsBsonDocument;
        if (deviceinfo.Contains("device_data"))
        {
            var deviceData = deviceinfo["device_data"].AsBsonDocument;
            var model = deviceData.GetValue("model", "").AsString; // "" instead of null
        }
    }
