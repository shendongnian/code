    void Foo()
    {
       GenericClient client = CreateClient(service);
      //do stuff with generic client
    }
    GenericClient CreateClient(string service)
    {
      switch(service)
      {
         case "DVSSync":
           return new WcfDVSSyncClient()
         //etc
      }
    }
