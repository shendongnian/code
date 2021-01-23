    public class DocumentController : Controller
    {
        private IDocumentService _documentService;
        // The controller doesn't construct the service itself
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        ...
    }
