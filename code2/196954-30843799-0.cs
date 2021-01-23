    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebQuoteServiceClient : System.ServiceModel.ClientBase<Corp.Legal.Webservices.ServiceReference1.IWebQuoteService>, Corp.Legal.Webservices.ServiceReference1.IWebQuoteService {
        
        public WebQuoteServiceClient()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
        }
