    public class MyOwnClassResponsibleForWebRequests
    {
       private MyOwnClassResponsibleForWebRequests(){}
    
       public HttpRequest Get(Params)
       {
          HttpRequestobj hr = new HttpRequest();
          .....your code
          return hr; //or make request and return result
       }
    }
