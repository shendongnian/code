[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
[XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
public partial class Envelope
{
    public EnvelopeBody Body { get; set; }
}
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public partial class EnvelopeBody
{
    [XmlElement(Namespace = "http://soap.api.controller.web.payjar.com/")]
    public doTransactionResponse doTransactionResponse { get; set; }
}
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://soap.api.controller.web.payjar.com/")]
[XmlRoot(Namespace = "http://soap.api.controller.web.payjar.com/", IsNullable = false)]
public partial class doTransactionResponse
{
    [XmlElement(Namespace = "")]
    public @return @return { get; set; }
}
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false)]
public partial class @return
{
    public string merchantReference { get; set; }
    public ulong MerReference { get; set; }
    public byte resultCode { get; set; }
    public string resultMessage { get; set; }
    public bool successful { get; set; }
}
**Code to use in the Main**
public static void Main(string[] args)
{
            string json = @"{
    ""id"": ""bf96aa5d-daf7-4de6-8ab0-c5ceb57b43af"",
    ""created"": ""1582519813359"",
    ""result"": {
        ""status"": ""Succeed""
    },
    ""amount"": 6789,
    ""provider_data"": {
        ""provider_name"": ""Magellan"",
        ""response_code"": ""00"",
        ""description"": ""Successful"",
        ""raw_response"": ""{\""raw_response\"":\""
<soap:Envelope xmlns:soap=\\\""http://schemas.xmlsoap.org/soap/envelope/\\\"">
<soap:Body><ns2:doTransactionResponse xmlns:ns2=\\\""http://soap.api.controller.web.payjar.com/\\\""><return>
<merchantReference>e5638752-be88-423b-8db8-e181db4825651582519812683</merchantReference>
<MerReference>14976972006762</MerReference>
<resultCode>00</resultCode>
<resultMessage>Successful</resultMessage><successful>true</successful></return>
</ns2:doTransactionResponse></soap:Body></soap:Envelope>\""}"",
        ""transaction_id"": ""14976972006762""
    }
}";
    // Convert the complete json first.
    var jobj = JObject.Parse(json);
    var mainRawResponse = jobj["provider_data"]["raw_response"].ToString();
    // Convert the string version of the object
    var soapResponse= JObject.Parse(mainRawResponse)["raw_response"].ToString();
    Envelope data = null;
    // Conver the SOAP response.
    using (var reader = new StringReader(soapResponse))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
        data = (Envelope)serializer.Deserialize(reader);
    }
// data variable holds the data you need from SOAP xml.
Console.WriteLine(data.Body.doTransactionResponse);
Console.WriteLine(((@return)data.Body.doTransactionResponse.@return).merchantReference);
}
