    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement xPolicyResponse = doc.Descendants("PolicyResponse").FirstOrDefault();
                PolicyResponse policyResponse = new PolicyResponse(xPolicyResponse); 
            }
        }
        public class PolicyResponse
        {
            public ServiceResponse serviceResponse { get; set; }
            public List<DetailResponse> detailResponse { get; set; }
            public PolicyResponse() {}
            public PolicyResponse(XElement element)
            {
                XElement xServiceResponse = element.Element("serviceResponse");
                List<XElement> xdetailResponseList = element.Descendants("detailResponse").ToList();
                serviceResponse = new ServiceResponse(xServiceResponse);
                detailResponse = xdetailResponseList.Select(x => new DetailResponse(x)).ToList();
            }
        }
        public class ServiceResponse
        {
            public int responseCode { get; set; }
            public string responseDescription { get; set; }
            public string responseDetail { get; set; }
            public int pageNum { get; set; }
            public int pageSize { get; set; }
            public int totalRecords { get; set; }
            public ServiceResponse() { }
            public ServiceResponse(XElement element)
            {
                responseCode = (int)element.Element("responseCode");
                responseDescription = (string)element.Element("responseDescription");
                responseDetail = (string)element.Element("responseDetail");
                pageNum = (int)element.Descendants("pageNum").FirstOrDefault();
                pageSize = (int)element.Descendants("pageSize").FirstOrDefault();
                totalRecords = (int)element.Descendants("totalRecords").FirstOrDefault();
            }
        }
        public class DetailResponse
        {
            public string policyNumber { get; set; }
            public string premiumChangeAmt { get; set; }
            public string writtenAmt { get; set; }
            public string policyStatusDesc { get; set; }
            public string insuredOrPrincipal { get; set; }                
            public DetailResponse() { }
            public DetailResponse(XElement element)
            {
                XElement xPolicySummaryInfo = element.Descendants("policySummaryInfo").FirstOrDefault();
                policyNumber = (string)xPolicySummaryInfo.Element("PolicyNumber");
                premiumChangeAmt = (string)xPolicySummaryInfo.Element("PremiumChangeAmt");
                writtenAmt = (string)xPolicySummaryInfo.Element("WrittenAmt");
                policyStatusDesc = (string)xPolicySummaryInfo.Element("PolicyStatusDesc");
                insuredOrPrincipal = (string)xPolicySummaryInfo.Descendants("InsuredOrPrincipal").FirstOrDefault();
            }
        }
    }
