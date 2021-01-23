    using System.Net.NetworkInformation;
    ...
    NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
    foreach (NetworkInterface adapter in interfaces)
    {
        if (adapter.OperationalStatus == OperationalStatus.Up)
        {
           // Do something
        }
    }
