    ForecastCollection collection = new ForecastCollection();
    ForecastCollection collection2 = null;
    collection.Add(new Weather());
    collection.Add(new Weather());
    collection.Add(new Weather());
    collection.Add(new Weather());
    collection.Add(new Weather());
    XmlSerializer xs = new XmlSerializer(typeof(ForecastCollection));
    using (Stream stream = new MemoryStream())
    {
        xs.Serialize(stream, collection);
        stream.Seek(0, SeekOrigin.Begin);
        collection2 = (ForecastCollection)xs.Deserialize(stream);
    }
    Boolean success = (collection2.Count == 5); // True
