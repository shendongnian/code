    [Route("/service1/GetData", "GET")]
    [Route("/service2/GetData", "GET")]
    public class GetData 
    { 
       public string MessageID {get;set;}
       public string Message {get;set;}
    }
