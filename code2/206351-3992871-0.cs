    using System.Web.Services;
    using System.Web.Services.Protocols;
    
    namespace Domain.WS
    {
        [Serializable]
        public class SoapWSHeader : System.Web.Services.Protocols.SoapHeader, ISoapWSHeader
        {
            public string UserId { get; set; }
            public string ServiceKey { get; set; }
            public ApplicationCode ApplicationCode { get; set; }        
        }    
    
        [WebService(Namespace = "http://domain.some.unique/")]        
        public class MyServices : System.Web.Services.WebService
        {
            public SoapWSHeader WSHeader;
            private ServicesLogicContext _logicServices;
    		
            public MyServices() { _logicServices = new ServicesLogicContext(new LogicInfo() {...}); }
    
            [WebMethod, SoapHeader("WSHeader", Direction = SoapHeaderDirection.InOut)]
            public Result WSMethod1(Int32 idSuperior)
            {
                _logicServices.ThrowIfNotAuthenticate(WSHeader); 
                return _logicServices.WSMethod1(idSuperior) as Result;
            }
        }
    }
    
    namespace Domain.Logic 
    {
        [Serializable]    
        public class ServicesLogicContext : ServicesLogicContextBase
        {
            protected ISoapWSHeader SoapWSHeader { get; set; }
            public ServicesLogicContext(LogicInfo info) : base(info) {}
    
            public IResult WSMethod1(Int32 idSuperior)
            {
                IResult result = null; 
    			//-- method implementation here...
                return result;
            }
    		
            public void ThrowIfNotAuthenticate(ISoapWSHeader soapWSHeader) {
                this.SoapWSHeader = soapWSHeader;
                if (SoapWSHeader != null)
                {
                    if (!ValidateCredentials(soapWSHeader))
                    {
                        throw new System.Security.SecurityException(Resources.ValidationErrorWrongCredentials);
                    }
                }
                else { throw new System.Security.SecurityException(Resources.ValidationErrorWrongWSHeader); }
            }
            private bool ValidateCredentials(ISoapWSHeader soapWSHeader) {   
                return (SoapWSHeader.UserId.Equals("USER_ID") && SoapWSHeader.ServiceKey.Equals("PSW_1"));
            }
        }
    }
