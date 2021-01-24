    public ProtoResponse SendResponse(Stream stream)
    {
       byte[] b;
       using (var memoryStream = new MemoryStream())
       {
          stream.CopyTo(memoryStream);
          b = memoryStream.ToArray();
       }
       var response = ProtoResponse
          {
             ResponseValue = ByteString.CopyFrom(b)
          }
       return response;
    }
