    using System.Linq;
    public List<string> Example()
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSStorageDriver_FailurePredictStatus");
        
        return searcher.Get().ToList();
    }
    public void Test()
    {
        var myList = Example();
        var element = myList[0];
    }
