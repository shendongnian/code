    // here is the factory
    public static class ClientFactory
    {
        public static ClientInterface GetClient(string clientCode)
        {
          // only 1 place in the code with a switch statement :)
          switch (clientCode)
          {
            case "abc": return new Client1();
            case "def": return new Client2();
            case "xyz": return new Client3();
            default: throw new Exception("code not supported: " clientCode);
          }
      }
    }
