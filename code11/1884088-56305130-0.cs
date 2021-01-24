    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    
    namespace ECSaveOrderRequest
    {
        /*
         * <SOAP:Envelope xmlns:SOAP='http://schemas.xmlsoap.org/soap/envelope/' > 
              <SOAP:Body UserGUID = '{redacted}' > 
              <m:SaveOrder xmlns:m = 'http://www.e-courier.com/schemas/' > 
                  <Order UserID = '1' Notes = 'Signature Requiered' CustomerID = '3' > 
                  </Order >  
               </m:SaveOrder > 
             </SOAP:Body >
     </SOAP:Envelope >*/
    
        public class Order
        {
            [XmlAttribute(AttributeName = "UserID")]
            public string UserID { get; set; }
    
            [XmlAttribute(AttributeName = "Notes")]
            public string Notes { get; set; }
    
            [XmlAttribute(AttributeName = "CustomerID")]
            public string CustomerID { get; set; }
        }
    
        public class SaveOrder
        {
            [XmlElement(ElementName = "Order", Namespace = "")]
            public Order Order { get; set; }
    
        }
    
        public class Body
        {
            [XmlElement(ElementName = "SaveOrder", Namespace = "http://www.e-courier.com/schemas/")]
            public SaveOrder SaveOrder { get; set; }
    
            [XmlAttribute(AttributeName = "UserGUID")]
            public string UserGUID { get; set; }
        }
    
        [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Envelope
        {
            [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public Body Body { get; set; }
            [XmlAttribute(AttributeName = "SOAP", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string SOAP { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var SaveOrder = new ECSaveOrderRequest.Envelope
                {
                    Body = new ECSaveOrderRequest.Body
                    {
                        UserGUID = "{redacted}",
                        SaveOrder = new ECSaveOrderRequest.SaveOrder
                        {
                            Order = new ECSaveOrderRequest.Order
                            {
                                UserID = "1",
                                Notes = "Signature Requiered",
                                CustomerID = "3"
                            }
                        }
    
                    }
                };
                var ns = new XmlSerializerNamespaces();
                ns.Add("SOAP", "http://schemas.xmlsoap.org/soap/envelope/");
                ns.Add("m", "http://www.e-courier.com/schemas/");
    
                var ser = new XmlSerializer(typeof(ECSaveOrderRequest.Envelope));
    
                var ms = new MemoryStream();
                // write the DTO to the MemoryStream
                ser.Serialize(ms, SaveOrder, ns);
    
                ms.Position = 0;
    
                var xml = Encoding.UTF8.GetString(ms.GetBuffer());
                Console.WriteLine(xml);
                Console.ReadKey();
    
    
    
            }
        }
    }
