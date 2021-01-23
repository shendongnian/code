    [DataContract(IsReference = true)]
    class X{
      [DataMember]
      public X another;
    }
    static void Main()
    {
      //from code:
      var first = new X();
      var second = new X();
      first.another = second;
      second.another = first;
      byte[] data;
      using (var stream = new MemoryStream())
      {
        var serializer = new DataContractSerializer(typeof(X));
        serializer.WriteObject(stream, first);
        data = stream.ToArray();
      }
      var str = Encoding.UTF8.GetString(data2);
    }
