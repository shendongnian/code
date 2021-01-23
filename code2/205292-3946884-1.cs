    public static string GetEmbeddedResourceText(string resourceName, Assembly resourceAssembly)
    {
       using (Stream stream = resourceAssembly.GetManifestResourceStream(resourceName))
       {
          int streamLength = (int)stream.Length;
          byte[] data = new byte[streamLength];
          stream.Read(data, 0, streamLength);
    
          // lets remove the UTF8 file header if there is one:
          if ((data[0] == 0xEF) && (data[1] == 0xBB) && (data[2] == 0xBF))
          {
             byte[] scrubbedData = new byte[data.Length - 3];
             Array.Copy(data, 3, scrubbedData, 0, scrubbedData.Length);
             data = scrubbedData;
          }
    
          return System.Text.Encoding.UTF8.GetString(data);
       }
    }
