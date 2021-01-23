    [DataContract(Namespace="http://yournamespace.com")
    public class MyContract
    {
       [DataMember(Order=1)]
       public string MyData1 { get(); set{};}
    
       [DataMember(order=2)]
       public string MyData2 { get(); set{};}
    
    }
