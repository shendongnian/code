// You can change this query to a more specific queue name or to get all queues
private const string WmiQuery = @"SELECT Name,MessagesinQueue FROM Win32_PerfRawdata_MSMQ_MSMQQueue WHERE Name LIKE 'private%myqueue'";
public int GetCount()
{
    using (ManagementObjectSearcher wmiSearch = new ManagementObjectSearcher(WmiQuery))
    {
        ManagementObjectCollection wmiCollection = wmiSearch.Get();
        foreach (ManagementBaseObject wmiObject in wmiCollection)
        {
            foreach (PropertyData wmiProperty in wmiObject.Properties)
            {
                if (wmiProperty.Name.Equals("MessagesinQueue", StringComparison.InvariantCultureIgnoreCase))
                {
                    return int.Parse(wmiProperty.Value.ToString());
                }
            }
        }
    }
}
Thanks to the `Microsoft.Windows.Compatibility` package this also works in netcore/netstandard. 
