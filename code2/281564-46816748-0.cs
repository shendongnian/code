    public class Customer: ICustomer{
         public Customer(Details details){
              Details = details;
         }
         [JsonProperty("Details",NullValueHnadling = NullValueHandling.Ignore)]
         public IDetails Details {get; set;}
    }
