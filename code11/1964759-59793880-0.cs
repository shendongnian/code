    var device = registryManager.GetDeviceAsync(deviceId).Result;
    var auth = new AuthenticationMechanism();
    auth.SymmetricKey.PrimaryKey = "<new primary key>";
    auth.SymmetricKey.SecondaryKey = device.Authentication.SymmetricKey.SecondaryKey;
    device = registryManager.UpdateDeviceAsync(new Device(deviceId) { Authentication = auth}, true).Result;
