    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    using System.Net;
    
    [System.Web.Services.WebServiceBindingAttribute(
    Name = "FunctionName",
    Namespace = "nameSpace")]
    public class ClassName:
    System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        public ClassName(string uri) // Constractor
        {
            this.Url = uri; // the full path for your server we  will make later on in the answer
        }
    
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
        "nameSpace/ClassName",
        RequestNamespace = "nameSpace",
        ResponseNamespace = "nameSpace",
        Use = System.Web.Services.Description.SoapBindingUse.Literal,
        ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    
        public object[] FunctionName(string Parameter1)
        {
            object[] results = { };
    
            try
            {
                results = this.Invoke("FunctionName", new object[] { Parameter1});
                return ((object[])(results[0]));
            }
            catch (Exception error)
            {
                object[] webException = { -1, error.Message };
                return (webException);
            }
        }
    }
