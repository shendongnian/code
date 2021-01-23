    var devices = document["devices"].AsBsonArray;
    if (devices.ToList().Count > 0)
    {
        if (devices[0].AsBsonDocument != null)
        {
            var deviceinfo = devices[0].AsBsonDocument;
            if (deviceinfo["device_data"].AsBsonDocument != null)
            {
                var deviceData = deviceinfo["device_data"].AsBsonDocument;
                model = deviceData.GetValue("model", null).AsString;
            }
        }
    }
