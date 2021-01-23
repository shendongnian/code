    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class FileService
    {
        private IncomingWebRequestContext m_Request;
        private OutgoingWebResponseContext m_Response;
        [WebGet(UriTemplate = "{appName}/{id}?action={action}")]
        public Stream GetFile(string appName, string id, string action)
        {
            var repository = new FileRepository();
            var response = WebOperationContext.Current.OutgoingResponse;
            var result = repository.GetById(int.Parse(id));
            if (action != null && action.Equals("download", StringComparison.InvariantCultureIgnoreCase))
            {
                response.Headers.Add("Content-Disposition", string.Format("attachment; filename={0}", result.Name));
            }
            response.Headers.Add(HttpResponseHeader.ContentType, result.ContentType);
            response.Headers.Add("X-Filename", result.Name);
            return result.Content;
        }
        [WebInvoke(UriTemplate = "{appName}", Method = "POST")]
        public void Save(string appName, Stream fileContent)
        {
            try
            {
                if (WebOperationContext.Current == null) throw new InvalidOperationException("WebOperationContext is null.");
                m_Request = WebOperationContext.Current.IncomingRequest;
                m_Response = WebOperationContext.Current.OutgoingResponse;
                var file = CreateFileResource(fileContent, appName);
                if (!FileIsValid(file)) throw new WebFaultException(HttpStatusCode.BadRequest);
                SaveFile(file);
                SetStatusAsCreated(file);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(WebFaultException)) throw;
                if (ex.GetType().IsGenericType && ex.GetType().GetGenericTypeDefinition() == typeof(WebFaultException<>)) throw;
                throw new WebFaultException<string>("An unexpected error occurred.", HttpStatusCode.InternalServerError);
            }
        }
        private FileResource CreateFileResource(Stream fileContent, string appName)
        {
            var result = new FileResource();
            fileContent.CopyTo(result.Content);
            result.ApplicationName = appName;
            result.Name = m_Request.Headers["X-Filename"];
            result.Location = @"C:\SomeFolder\" + result.Name;
            result.ContentType = m_Request.Headers[HttpRequestHeader.ContentType] ?? this.GetContentType(result.Name);
            result.DateUploaded = DateTime.Now;
            return result;
        }
        
        private string GetContentType(string filename)
        {
            // this should be replaced with some form of logic to determine the correct file content type (I.E., use registry, extension, xml file, etc.,)
            return "application/octet-stream";
        }
        private bool FileIsValid(FileResource file)
        {
            var validator = new FileResourceValidator();
            var clientHash = m_Request.Headers[HttpRequestHeader.ContentMd5];
            return validator.IsValid(file, clientHash);
        }
        private void SaveFile(FileResource file)
        {
            // This will persist the meta data about the file to a database (I.E., size, filename, file location, etc)
            new FileRepository().AddFile(file);
        }
        private void SetStatusAsCreated(FileResource file)
        {
            var location = new Uri(m_Request.UriTemplateMatch.RequestUri.AbsoluteUri + "/" + file.Id);
            m_Response.SetStatusAsCreated(location);
        }
    }
