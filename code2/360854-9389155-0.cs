    public class SomeBusinessLogic
    {
       public Result HandleDocument(IDocument doc)
       {
           // some transformations...
     
           int hash = Hashing.ReSharperHash.CalculateHash(seed, doc.Properties);
    
           // some other code ...
       }
    }
