    abstract class BaseRep : IRep
    {
        void Add(object a)
        {
           if(OkToAdd(a))
           {
              // Common Rep code here
           }
        }
    
        void Remove(object a)
        {
           if(OkToRemove(b))
           {
              // Common Rep code here
           }
        }
    
        abstract bool OkToAdd(object a);
        abstract bool OkToRemove(object a);
    }
    
