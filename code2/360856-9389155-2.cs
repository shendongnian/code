    public class SomeBusinessLogic
    {
       // injection in constructor
       public SomeBusinessLogic(IHashingAlgorithm hashing)
       {
           // put hashing in a field of the class
       }
       // OR injection in method itself, if hashing is only used in this method
       public Result HandleDocument(IDocument doc, IHashingAlgorithm hashing)
       {
           // some transformations...
     
           int hash = hashing.CalculateHash(seed, doc.Properties);
    
           // some other code ...
       }
    }
