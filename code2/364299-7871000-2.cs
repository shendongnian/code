    <%@ WebService Language="c#"
          Class="Cheeso.CooperService"
          %>
    using System.Web.Services;
    using System.Web.Services.Description;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.Collections;
    namespace Cheeso
    {
        [SoapType(Namespace="http://www.smarteam.com/dev/ns/SOF/2.0")]
        public class DictionaryItem
        {
            public string key { get; set; }
            public string value { get; set; }
        }
        [System.Web.Services.WebService
         (Name="EngineSoapBinding",
          Namespace="http://www.smarteam.com/dev/ns/iplatform/embeddedscripts/wsdl/")]
        public class CooperService : System.Web.Services.WebService
        {
            [WebMethod]
            [SoapRpcMethod
             ("http://www.smarteam.com/dev/ns/iplatform/embeddedscripts/action/Execute",
              RequestNamespace="http://www.smarteam.com/dev/ns/iplatform/embeddedscripts",
              ResponseNamespace="http://www.smarteam.com/dev/ns/iplatform/embeddedscripts",
              Use=SoapBindingUse.Encoded)]
            [return: System.Xml.Serialization.SoapElementAttribute("Result")]
            public object Execute(string ContextHandle,
                                  string ScriptLanguage,
                                  string Script,
                                  DictionaryItem[] Params)
            {
                return "The answer is 42. What is the question?";
            }
        }
    }
