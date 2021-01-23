    [DataContract]
    [KnownType(typeof(ClassA))]
    public abstract class ClassABase()
    {
    
    }
    
    [DataContract]
    public classA :ClassABase
    {
    
    }
    
    //WCF:
    public void MethodA(ClassABase a)
    {
    
    }
