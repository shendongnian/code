        // Convert an object to a byte array
        private byte[] ObjectToByteArray(Object obj)
        {
           if(obj == null)
           return null;
           BinaryFormatter bf = new BinaryFormatter();
           MemoryStream ms = new MemoryStream();
           bf.Serialize(ms, obj);
           return ms.ToArray();
        }
    
    // Convert a byte array to an Object
        private Object ByteArrayToObject(byte[] arrBytes)
        {
          MemoryStream memStream = new MemoryStream();
          BinaryFormatter binForm = new BinaryFormatter();
          memStream.Write(arrBytes, 0, arrBytes.Length);
          memStream.Seek(0, SeekOrigin.Begin);
          Object obj = (Object) binForm.Deserialize(memStream);
          return obj;
        }
