    // Single using
    using (StreamWriter writer = new StreamWriter(
                                                 "Shipping2.txt", 
                                                 true, // !!!
                                                 Encoding.ASCII))
    {
           foreach (var shipment in _shipments)
           {
               string write = (shipment.Distance + "," + shipment.Distance)
                              .ToString();
               writer.WriteLine(write);
           }
    }
