using Newtonsoft.Json;
public class Payload
{
    public string customerProfileId;
    public string entityName;
}
public class Transaction
{
    public string notification = "";
    public string eventType = "";
    public DateTime eventDate ;
    public string webhookId  = "";
    public Payload payload = null;
}
var myJson =  
 @"{""notificationId"":""29397081-d4ed-4d2a-a672-4e875eabf535"", ""eventType"":""net.authorize.customer.paymentProfile.deleted"", ""eventDate"":""2019-08-15T15:36:34.7856727Z"", ""webhookId"":""183a9022-510b-4801-a50c-75ef7310844f"", ""payload"": {""customerProfileId"":1920340068, ""entityName"":""customerPaymentProfile"", ""id"":""1833395942""}}";
Transaction myTransaction = JsonConvert.DeserializeObject<Transaction>(myJson);
