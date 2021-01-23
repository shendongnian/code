    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml;
     
    namespace Ryadel.Web.SOAP
    {
        /// <summary>
        /// Helper class to send custom SOAP requests.
        /// </summary>
        public static class SOAPHelper
        {
            /// <summary>
            /// Sends a custom sync SOAP request to given URL and receive a request
            /// </summary>
            /// <param name="url">The WebService endpoint URL</param>
            /// <param name="action">The WebService action name</param>
            /// <param name="parameters">A dictionary containing the parameters in a key-value fashion</param>
            /// <param name="soapAction">The SOAPAction value, as specified in the Web Service's WSDL (or NULL to use the url parameter)</param>
            /// <param name="useSOAP12">Set this to TRUE to use the SOAP v1.2 protocol, FALSE to use the SOAP v1.1 (default)</param>
            /// <returns>A string containing the raw Web Service response</returns>
            public static string SendSOAPRequest(string url, string action, Dictionary<string, string> parameters, string soapAction = null, bool useSOAP12 = false)
            {
                // Create the SOAP envelope
                XmlDocument soapEnvelopeXml = new XmlDocument();
                var xmlStr = (useSOAP12)
                    ? @"<?xml version=""1.0"" encoding=""utf-8""?>
                        <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                          xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                          xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
                          <soap12:Body>
                            <{0} xmlns=""{1}"">{2}</{0}>
                          </soap12:Body>
                        </soap12:Envelope>"
                    : @"<?xml version=""1.0"" encoding=""utf-8""?>
                        <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" 
                            xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                            xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                            <soap:Body>
                               <{0} xmlns=""{1}"">{2}</{0}>
                            </soap:Body>
                        </soap:Envelope>";
                string parms = string.Join(string.Empty, parameters.Select(kv => String.Format("<{0}>{1}</{0}>", kv.Key, kv.Value)).ToArray());
                var s = String.Format(xmlStr, action, new Uri(url).GetLeftPart(UriPartial.Authority) + "/", parms);
                soapEnvelopeXml.LoadXml(s);
     
                // Create the web request
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Headers.Add("SOAPAction", soapAction ?? url);
                webRequest.ContentType = (useSOAP12) ? "application/soap+xml;charset=\"utf-8\"" : "text/xml;charset=\"utf-8\"";
                webRequest.Accept = (useSOAP12) ? "application/soap+xml" : "text/xml";
                webRequest.Method = "POST";
     
                // Insert SOAP envelope
                using (Stream stream = webRequest.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }
     
                // Send request and retrieve result
                string result;
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        result = rd.ReadToEnd();
                    }
                }
                return result;
            }
        }
    }
