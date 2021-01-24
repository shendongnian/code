[DataContract]
public class Base 
{
   [DataMember(Name="livemode")]
   public bool Livemode {get;set;}
   [DataMember(Name="object")]
   public string @Object {get;set;}
   [DataMember(Name="id")]
   public string Id {get;set;}
}
[DataContract]
public class Event:Base
{
   [DataMember(Name="created")]
   public long Created {get;set;}   
   [DataMember(Name="type")]
   public string Type {get;set;}
   [DataMember(Name="data")]
   public EventData Data {get;set;}
}
[DataContract]
public class EventData
{
   [DataMember(Name="object")]
   public EventObject EventObject {get;set;}
}
[DataContract]
public class EventObject:Base
{
   [DataMember(Name="display_items")]
   public Item[] DisplayItems {get;set;}
}
[DataContract]
public class Item
{
   [DataMember(Name="amount")]
   public double Amount {get;set;}
   [DataMember(Name="currency")]
   public string Currency {get;set;}
}
I use that DataContract in this Service Contract:
[ServiceContract]
interface IContract 
{
   [OperationContract]
   [WebInvoke(
   		Method = "POST",
		BodyStyle = WebMessageBodyStyle.Bare,
		ResponseFormat = WebMessageFormat.Json,
		RequestFormat = WebMessageFormat.Json)]
   string StripeWebhook(Event data); 
}
When I create an implementation for that service:
public class JsonService:IContract 
{
  public  string StripeWebhook(Event data)
  {  
	data.Dump("rcvd data");
    return "{\"result\":\"success\"}";
  }
}
and feed that into a WebServiceHost:
// keeps the service running
AutoResetEvent are = new AutoResetEvent(false);
void Start() 
{
  //netsh http add urlacl url=http://+:8000/json user=USERNAME
  using (var serviceHost = new WebServiceHost(typeof(JsonService), new Uri("http://localhost:8000/json")))
  {
	  serviceHost.AddServiceEndpoint(typeof(IContract), new WebHttpBinding(), "");
      serviceHost.Open();
      are.WaitOne(); // blocks 
      serviceHost.Close();
  }
}
I can call that service once I started it and POST the JSON to it:
void Main()
{
    new Thread(Start).Start();	
	try {
		var wc = new WebClient();
		wc.Headers.Add("content-type","application/json");
		wc.UploadString("http://localhost:8000/json/Stripewebhook", File.ReadAllText(@"example_json_wcf.json")).Dump("response");
	} catch(WebException e) {
	   e.Dump("raw");
	   using(var ms = new MemoryStream()) {
		   e.Response.GetResponseStream().CopyTo(ms);
		   Encoding.UTF8.GetString(ms.ToArray()).Dump("error");
	   }
	}
	Console.WriteLine("Now Running. Enter key will stop the service.");
    Console.ReadLine();
	are.Set();
}
This is what my result looks like in LinqPad:
[![POCO classes filled with data][1]][1]
Keep in mind:
- Bare or Wrapped does matter  
- In (de)serialization casing matters  
If deserialization fails, try to serialize your object tree first and then compare that result with what you actually need.  
Or use one of many JSON to POCO services, for example: http://json2csharp.com/ (I'm not affiliated with that service, it just happened to be the first that popped up in my Google Search)
  [1]: https://i.stack.imgur.com/YG92m.png
