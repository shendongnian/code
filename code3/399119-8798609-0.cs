    //Attachment Class
    public class Attachment
    {
        #region Properties
        public virtual Guid AttachmentId { get; set; }
        public virtual int? ContentLength { get; set; }
        public virtual string ContentType { get; set; }
        public virtual byte[] Contents { get; set; }
        public virtual DateTime? DateAdded { get; set; }
        public virtual string FileName { get; set; }
        public virtual string Tag { get; set; }
        public virtual string Title { get; set; }
        #endregion
     }
    
    public class AttachmentController : Controller
    {
         IAttachmentService attachmentService;
        public AttachmentController(IAttachmentService attachmentService)
        {
            this.attachmentService = attachmentService;
        }
        public ActionResult Index(Guid id)
        {
            var attachment = this.attachmentService.GetById(id);
            return attachment.IsNull() ? null : this.File(attachment.Contents, attachment.ContentType,attachment.FileName);
        }
    }
    public class AttachmentModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase httpRequestBase = controllerContext.RequestContext.HttpContext.Request;
            HttpPostedFileBase @base = httpRequestBase.Files[bindingContext.ModelName];
            var converter = new FileConverter();
            Attachment attachment = converter.Convert(
                    new ResolutionContext(
                        new TypeMap(new TypeInfo(typeof(HttpPostedFileWrapper)), new TypeInfo(typeof(Attachment))),
                        @base,
                        typeof(HttpPostedFileWrapper),
                        typeof(Attachment)));
            }
			return attachment;
		}
	}
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinders.Binders[typeof(Attachment)] = new AttachmentModelBinder();
        }
    }
