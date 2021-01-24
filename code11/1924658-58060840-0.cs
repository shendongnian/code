    var jsonStrings = await query.GetNextAsJsonAsync();
    var deviceProperties = jsonStrings.Select(JsonConvert.DeserializeObject<DeviceProperty>);
    return (ActionResult)new OkObjectResult(deviceProperties);
    public class DeviceProperty
    {
        public string Plant { get; set; }
    }
