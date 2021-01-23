    internal static void SaveFileAsTxt()
    {
        using(var streamer = new FileStream("Shipping2.txt", FileMode.Append, FileAccess.Write, FileShare.Write))
        {
        }
        using(var f = File.Open("Shipping2.txt", FileMode.Create)) 
        {
        }
        using(var writer = new StreamWriter("Shipping2.txt", true, Encoding.ASCII))
        {
            foreach (var shipment in _shipments)
            {
                string write = (shipment.Distance + ","+ shipment.Distance).ToString();
                writer.WriteLine(write);
            };
        }
    }
