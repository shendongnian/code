    private static void SerializeAndEncrypt<T>(T data)
    {                
      ...
      _toEncrypt = memoryStreamReader.ReadToEnd();
      cryptoStreamWriter.Write(_toEncrypt);
      // Flush your stream writer. So all buffered
      // data get written to the underlying device.
      cryptoStreamWriter.Flush(); 
      cryptoStream.Close();
      fileStream.Close();
      memoryStream.Close();
    }
    private static T DecryptAndDeserialize<T>()
    {
      ...
      _decrypted = cryptoStreamReader.ReadToEnd();
      memoryStreamWriter.Write(_decrypted);
  
      // Flush buffered data.
      memoryStreamWriter.Flush();
      memoryStream.Position = 0L;
      var serializer = new DataContractSerializer(typeof(T));
      var result = (T)serializer.ReadObject(memoryStream);
      memoryStream.Close();
      cryptoStream.Close();
      fileStream.Close();
      return result;
    }
