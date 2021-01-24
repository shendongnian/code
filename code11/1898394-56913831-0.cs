    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string responseText = File.ReadAllText(FILENAME);
                StringReader reader = new StringReader(responseText);
                XmlReader xReader = XmlReader.Create(reader);
                XmlSerializer serializer = new XmlSerializer(typeof(IntuitResponse));
                IntuitResponse response = (IntuitResponse)serializer.Deserialize(xReader);
            }
        }
        [XmlRoot(ElementName = "IntuitResponse", Namespace = "http://schema.intuit.com/finance/v3")]
        public class IntuitResponse
        {
            [XmlAttribute("time")]
            public DateTime time { get; set; }
            [XmlElement(ElementName = "QueryResponse", Namespace = "http://schema.intuit.com/finance/v3")]
            public QueryResponse response { get; set; }
        }
       
        public class QueryResponse
        {
            [XmlAttribute("startPosition")]
            public int startPosition { get; set; }
            [XmlAttribute("maxResults")]
            public int maxResults { get; set; }
            [XmlAttribute("totalCount")]
            public int totalCount { get; set; }
            [XmlElement(ElementName = "Invoice", Namespace = "http://schema.intuit.com/finance/v3")]
            public Invoice invoice { get; set; }
        }
        public class Invoice
        {
            [XmlAttribute("domain")]
            public string domain { get; set; }
            [XmlAttribute("sparse")]
            public Boolean sparse { get; set; }
            public int Id { get; set; }
            public int SyncToken { get; set; }
            [XmlElement(ElementName = "MetaData", Namespace = "http://schema.intuit.com/finance/v3")]
            public MetaData metaData { get; set; }
            [XmlElement(ElementName = "CustomField", Namespace = "http://schema.intuit.com/finance/v3")]
            public CustomField customField { get; set; }
            public int DocNumber { get; set; }
            public DateTime TxnDate { get; set; }
            [XmlElement(ElementName = "CurrencyRef", Namespace = "http://schema.intuit.com/finance/v3")]
            public CurrencyRef currencyRef { get; set; }
            public int ExchangeRate { get; set; }
            public string PrivateNote { get; set; }
            [XmlElement(ElementName = "Line", Namespace = "http://schema.intuit.com/finance/v3")]
            public List<Line> line { get; set; }
            [XmlElement(ElementName = "TxnTaxDetail", Namespace = "http://schema.intuit.com/finance/v3")]
            public TxnTaxDetail txnTaxDetail { get; set; }
            [XmlElement(ElementName = "CustomerRef", Namespace = "http://schema.intuit.com/finance/v3")]
            public CustomerRef CustomerRef { get; set; }
            public DateTime DueDate { get; set; }
            public int TotalAmt { get; set; }
            public int HomeTotalAmt { get; set; }
            public Boolean ApplyTaxAfterDiscount { get; set; }
            public string PrintStatus { get; set; }
            public string EmailStatus { get; set; }
            public int Balance { get; set; }
            public int Deposit { get; set; }
            public Boolean AllowIPNPayment { get; set; }
            public Boolean AllowOnlinePayment { get; set; }
            public Boolean AllowOnlineCreditCardPayment { get; set; }
            public Boolean AllowOnlineACHPayment { get; set; }
        }
        public class MetaData
        {
            public DateTime CreateTime { get; set; }
            public DateTime LastUpdatedTime { get; set; }
        }
        public class CustomField
        {
            public int DefinitionId { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string StringValue { get; set; }
        }
        public class CurrencyRef
        {
            [XmlAttribute("name")]
            public string name { get; set; }
            [XmlText]
            public string value { get; set; }
        }
        public class Line
        {
            public int Id { get; set; }
            public int LineNum { get; set; }
            public string Description { get; set; }
            public decimal Amount { get; set; }
            public string DetailType { get; set; }
            [XmlElement(ElementName = "SalesItemLineDetail", Namespace = "http://schema.intuit.com/finance/v3")]
            public SalesItemLineDetail salesItemLineDetail { get; set; }
        }
        public class CustomerRef
        {
            [XmlAttribute("name")]
            public string name { get; set; }
            [XmlText]
            public string value { get; set; }
        }
        public class SalesItemLineDetail
        {
            [XmlElement(ElementName = "ItemRef", Namespace = "http://schema.intuit.com/finance/v3")]
            public ItemRef itemRef { get; set; }
            public int Qty { get; set; }
            public string TaxCodeRef { get; set; }
        }
        public class ItemRef
        {
            [XmlAttribute("name")]
            public string name { get; set; }
            [XmlText]
            public string value { get; set; }
        }
        public class TxnTaxDetail
        {
            public int TotalTax { get; set; }
        }
    }
