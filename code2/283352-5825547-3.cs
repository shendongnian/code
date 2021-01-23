    // put all methods any client will ever need here
    public interface IClient 
    {
        string FunctionA(string a);
        string FunctionB(string a, string b, string c);
        string FunctionC(string a, string b);
        string FunctionD();
    }
    // now give a nice default implementation
    internal abstract class DefaultClient : IClient
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
    internal class Client1 : DefaultClient
    {
        // implement functionB and functionC here
    }
    
    internal class Client2 : DefaultClient
    {
        // implement functionB and functionC here
    }
    
    internal class Client3 : DefaultClient
    {
        // implement functionB, functionC and functionD here
    }
    
