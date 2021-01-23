      public static T Clone<T>(T obj)
      {
          DataContractSerializer dcSer = new  DataContractSerializer(obj.GetType());
          MemoryStream memoryStream = new MemoryStream();
          dcSer.WriteObject(memoryStream, obj);
          memoryStream.Position = 0;
          T newObject = (T)dcSer.ReadObject(memoryStream);
          return newObject;
      }
