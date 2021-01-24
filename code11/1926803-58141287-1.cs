`
 <S:Envelope xmlns:S="http://schemas.xmlsoap.org/soap/envelope/">
   <S:Body>
     <ns2:loginResponse xmlns:ns2="http://webservices/">
`
 - Your root `return` object has another nested object called `xml` in it, so you should add an `xml` class in there, like this:
`
    [Serializable()]
    [XmlRoot("return")]
    public class Response
    {
        private Xml xml { get; set; };
    }
    private class Xml
    {
        private string ticket { get; set; };
        private string name { get; set; };
        private string profile { get; set; };
        private string companyId { get; set; };       
        private string storeId { get; set; };
        private string terminalId { get; set; };
        private string accountNo { get; set; };
        private bool postae { get; set; };
        private bool postaeproduct { get; set; };
    }
`
