    // Initialize the serializer to write and read the data
    XmlSerializer serializer = new XmlSerializer(typeof(CustomerData));
    // Initialize the data to serialize
    CustomerData dataToWrite = new CustomerData()
    {
        Name = "Joel Spolsky",
        City = "New York",
        Company = "Fog Creek Software"
    };
    // Write it out
    XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
    using (XmlWriter writer = XmlTextWriter.Create("customer.xml", settings))
    {
        serializer.Serialize(writer, dataToWrite);
    }
    // Read it back in
    CustomerData dataFromFile = null;
    using (XmlReader reader = XmlTextReader.Create("customer.xml"))
    {
        dataFromFile = (CustomerData)serializer.Deserialize(reader);
    }
    Console.WriteLine(dataFromFile);
