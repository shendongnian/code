    public static class ObjectXMLSerializer {
      public static void Save(object objectToSerialize, string fileName) {
        var serializer = new XmlSerializer(objectToSerialize.GetType());
        using (var stream = File.OpenWrite(fileName)) {
          serializer.Serialize(stream, objectToSerialize);
        }
      }
    }
