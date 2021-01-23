    using System.Linq;
    using System.Xml.Linq;
    
    
    namespace ConsoleApplication5
    {
      class Program
      {    
        static void Main(string[] args)
        {
          string xml = @"<AcknowledgementList xmlns=""http://www.irs.gov/efile"" xmlns:efile=""http://www.irs.gov  /efile"">
             <efile:Acknowledgement>
         <efile:SubmissionId>4654652011356f7ovyf5</efile:SubmissionId>
             <efile:EFIN>465465</efile:EFIN>
             <efile:TaxYear>2011</efile:TaxYear>
             <efile:GovernmentCode>OHST</efile:GovernmentCode>
             </efile:Acknowledgement>
              </AcknowledgementList>";
    
          XDocument doc = XDocument.Parse(xml, LoadOptions.PreserveWhitespace);
          doc.Descendants().Attributes().Where(a => a.IsNamespaceDeclaration).Remove();
          xml = doc.CreateReader().ReadString();
    
          System.Diagnostics.Debug.WriteLine (xml);
    
        }
      }
    }
