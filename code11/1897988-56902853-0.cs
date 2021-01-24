    using Microsoft.Azure.Devices;
    
    RegistryManager registryManager = RegistryManager.CreateFromConnectionString("registryreadconnectionstring");
               
    Device device = await registryManager.GetDeviceAsync("device-id");
    
    var count  = device.CloudToDeviceMessageCount;
