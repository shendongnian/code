    public string GetColorsXmlRepresentation()
    {
        var colors = new List<Color>();
    
        colors.Add(new Color {Name = "Red", Code = 1});
        colors.Add(new Color {Name = "Blue", Code = 2});
    
        return Serialize<List<Color>>(colors);
    }
    
    
    public string Serialize<T>(T instance)
    {
        var data = new StringBuilder();
        var serializer = new DataContractSerializer(instance.GetType());
    
        using (var writer = XmlWriter.Create(data))
        {
           serializer.WriteObject(writer, instance);
           writer.Flush();
    
          return data.ToString();
        }
    }
