    public class RazorHtmlHandler : HttpOperationHandler<HttpResponseMessage, HttpResponseMessage>
    {
        public static readonly String OUTPUT_PARAMETER_NAME = "response";
        public static readonly MediaTypeWithQualityHeaderValue HTML_MEDIA_TYPE = new MediaTypeWithQualityHeaderValue("text/html");
        public const String DEFAULT_TEMPLATE_NAME = "index.cshtml";
        public const String DEFAULT_TEMPLATE_EXTENSION = ".cshtml";
        public const String DEFAULT_RAZOR_NAME = "_RazorHtmlProcessor_Template";
        public RazorHtmlHandler() : base(OUTPUT_PARAMETER_NAME)
        { }
        protected override HttpResponseMessage OnHandle(HttpResponseMessage response)
        {
            var request = response.RequestMessage;
            var accept = request.Headers.Accept;
            if (!accept.Contains(HTML_MEDIA_TYPE))
                return response;
            var buffer = new StringBuilder();
            var currentContent = response.Content as ObjectContent;
            try
            {                
                var template = LoadTemplateForResponse(request.RequestUri, currentContent);
                var value = ReadValueFormObjectContent(currentContent);
                buffer.Append(InvokeRazorParse(template, value));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            response.Content = new StringContent(buffer.ToString(), 
                                                 Encoding.UTF8, 
                                                 HTML_MEDIA_TYPE.MediaType);
            return response;
        }
        ...
    }
