    // put all methods any client will ever need here
    public interface ClientInterface 
    {
        string FunctionA(string a);
        string FunctionB(string a, string b, string c);
        string FunctionC(string a, string b);
        string FunctionD();
    }
    // now give a nice default implementation
    public abstract class DefaultClient
    {
        //all clients have the same functionA, for now, don't even allow overriding
        public string FunctionA(string a)
        {
            return "hello: " + a;
        }
 
        //function B and C differ from client to client make them abstract
        public abstract string FunctionB(string a, string b, string c);
        public abstract string FunctionC(string a, string b);
        
        //functionD isn't usually needed, but sometimes has an implementation
        public virtual string FunctionD()
        {
             // do nothing I guess
        }
    }
    class Client1
    {
        // implement functionB and functionC here
    }
    
    class Client2
    {
        // implement functionB and functionC here
    }
    
    class Client3
    {
        // implement functionB, functionC and functionD here
    }
    
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
