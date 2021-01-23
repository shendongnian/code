    public string ToXml(DataSet ds)
    {
      using (var memoryStream = new MemoryStream())
      {
        using(TextWriter streamWriter = new StreamWriter(memoryStream))
        {
          var xmlSerializer = new XmlSerializer(typeof(DataSet));
          xmlSerializer.Serialize(streamWriter, ds);
          return Encoding.UTF8.GetString(memoryStream.ToArray());
        }
      }
    }
