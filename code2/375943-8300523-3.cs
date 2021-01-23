    <li><a href="...webservices/ControlServce.svc/Content?cType=Rewards" class="wrapper active"></a></li> 
    /// <summary>
    /// Service used by ajax for loading social media content
    /// </summary>
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ControlService
    {
        /// <summary>
        /// Streams html content
        /// </summary>
        /// <param name="type">type of control</param>
        /// <returns>html stream of content</returns>
        [OperationContract]
        [WebGet(UriTemplate = "Content?cType={cType}")]
        public Stream GetContent(string cType)
        {
            var tw = new StringWriter();
            var writer = new Html32TextWriter(tw);
            var page = new Page();
            var control = page.LoadControl(cType);
            control.RenderControl(writer);
            writer.Close();
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(tw.ToString()));
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            return stream;
        }
    }
