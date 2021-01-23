      public static T Load<T>(string fileName) { 
        var serializer = new XmlSerializer(typeof(T));
        using (var stream = File.OpenRead(fileName)) {
          return (T)serializer.Deserialize(stream);
        }
      } 
