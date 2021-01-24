    [Route("/service1/GetData", "GET")]
    public class GetData1
    { 
       public string MessageID {get;set;}
       public string Message {get;set;}
    }
    [Route("/service2/GetData", "GET")]
    public class GetData2
    { 
       public string MessageID {get;set;}
       public string Message {get;set;}
    }
