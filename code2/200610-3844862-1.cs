    public sealed class RequestType
    {
         public static readonly RequestType CustomerLookup = new RequestType("005");
         // etc
         public string Code { get; private set; }
         private RequestType(string code)
         {
             this.Code = code;
         }
    }
