    namespace WebTest
    {
        public struct UploadResponse
        {
            public string wwretval;
            public string wwrettext;
        }
    
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.None)]
        [System.ComponentModel.ToolboxItem(false)]
    
        public class Service1 : System.Web.Services.WebService
        {
    
            [SoapRpcMethod(ResponseElementName = "UploadResponse",Use=SoapBindingUse.Literal)]
            [WebMethod]
            public UploadResponse Upload()
            {
               UploadResponse ww = new UploadResponse();
    
                ww.wwretval = "Hello";
                ww.wwrettext = "World";
                return ww;
            }
        }
    }
