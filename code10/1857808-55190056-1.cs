C#
public async Task ProcessStart()
{
  string messageData = "{\"name\":\"DemoData\",\"no\":\"111\"}";
  RegistryManager registryManager;
  var tasks = deviceList.Select(async device =>
  {
    // get details for each device and use key to send message
    device = await registryManager.GetDeviceAsync(device.DeviceId);
    await SendMessagesAsync(device.DeviceId, device.Key, messageData);
  }).ToList();
  await Task.WhenAll(tasks);
}
private async Task SendMessagesAsync(string deviceId, string Key, string messageData)
{
  DeviceClient deviceClient = DeviceClient.Create(hostName, new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey), Microsoft.Azure.Devices.Client.TransportType.Mqtt);
  await ProcessMessagesAsync(deviceId, string messageData);
}
private async Task ProcessMessagesAsync(string deviceId, string messageData)
{
  var startTime = DateTime.UtcNow;
  while (DateTime.UtcNow - startTime < TimeSpan.FromMinutes(15))
  {
    await deviceClient.SendEventAsync(messageData);
  }
}
> for 10k it got timeout issue.
15 minutes is a *long* time for an HTTP request. I think it would be worthwhile to take a step back and see if there's a better way to architect the whole system.
