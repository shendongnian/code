    static void Main(string[] args)
    {
        Func<PropertyData, bool> indicatesPhysical = property => property.Name == "EnableBIDI"; // && (bool) property.Value;
        Func<ManagementBaseObject, bool> isPhysicalPrinter = obj => obj.Properties.OfType<PropertyData>().Any(indicatesPhysical);
        var searcher = new ManagementObjectSearcher("Select * from Win32_Printer");
        var collection = searcher.Get();
        var physicalPrinters = collection.OfType<ManagementBaseObject>().Where(isPhysicalPrinter);
        foreach (var item in physicalPrinters)
        {
            Console.WriteLine(item.Properties["DeviceID"].Value);
            Console.WriteLine(item.Properties["EnableBIDI"].Value);
        }
    }
