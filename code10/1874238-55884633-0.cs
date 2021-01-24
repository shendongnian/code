lang-cs
// using System.ServiceModel.Description;
// using System.ServiceModel.Dispatcher;
// using System.ServiceModel.Channels;
// using System.ServiceModel
public class InspectBehaviorAndnspector : IEndpointBehavior, IClientMessageInspector
{
   
    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
        clientRuntime.MessageInspectors.Add(this);
    }
    
    public MessageBuffer RequestBuffer;
    public MessageBuffer ReplyBuffer;
    
    public void AfterReceiveReply(ref Message reply, object correlationState){
       // messages are read only
       ReplyBuffer = reply.CreateBufferedCopy(2048);
       // so recreate the message after it was buffered
       reply = ReplyBuffer.CreateMessage();
    }
   
    public object BeforeSendRequest(ref Message request, IClientChannel channel){
       // messages are read only
       RequestBuffer = request.CreateBufferedCopy(2048);
       // so recreate the message after it was buffered
       request = RequestBuffer.CreateMessage();
       return "42";
    }
    
    // not needed for client
    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
    }
    
    public void Validate(ServiceEndpoint sep) 
    {
    }
    public void AddBindingParameters(ServiceEndpoint sep, BindingParameterCollection bpc)
    {
    }
}
Now on your `client` instance, assuming it derives from `ClientBase`, you can do:
var inspector = new InspectBehaviorAndnspector();
client.Endpoint.Behaviors.Add(inspector);
// this is your call
var response = client.invoke(parameter);
// either do a ToString
Console.WriteLine(inspector.RequestBuffer.CreateMessage().ToString());
// or Write it with XmlWriter
var sb = new StringBuilder();
using(var xw = XmlWriter.Create(sb, new XmlWriterSettings {Indent =true})) {
    inspector.ReplyBuffer.CreateMessage().WriteMessage(xw);
}
Console.WriteLine(sb.ToString());
I have run this on an example with an Add service and this was my result:
lang-xml
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
  <s:Header>
    <Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://tempuri.org/ISelfHostTest/Add</Action>
  </s:Header>
  <s:Body>
    <Add xmlns="http://tempuri.org/">
      <x>3</x>
      <y>2</y>
    </Add>
  </s:Body>
</s:Envelope>
<?xml version="1.0" encoding="utf-16"?>
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
  <s:Body>
    <AddResponse xmlns="http://tempuri.org/">
      <AddResult>5</AddResult>
    </AddResponse>
  </s:Body>
</s:Envelope>
