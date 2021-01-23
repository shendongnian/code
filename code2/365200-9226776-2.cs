    public class GridAttribute : GridActionAttribute, IActionFilter
      {    
        /// <summary>
        /// Determines the depth that the serializer will traverse
        /// </summary>
        public int SerializationDepth { get; set; } 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="GridActionAttribute"/> class.
        /// </summary>
        public GridAttribute()
          : base()
        {
          ActionParameterName = "command";
          SerializationDepth = 1;
        }
    
        protected override ActionResult CreateActionResult(object model)
        {    
          return new EFJsonResult
          {
           Data = model,
           JsonRequestBehavior = JsonRequestBehavior.AllowGet,
           MaxSerializationDepth = SerializationDepth
          };
        }
    }
    public class EFJsonResult : JsonResult
      {
        const string JsonRequest_GetNotAllowed = "This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.";
    
        public EFJsonResult()
        {
          MaxJsonLength = 1024000000;
          RecursionLimit = 10;
          MaxSerializationDepth = 1;
        }
    
        public int MaxJsonLength { get; set; }
        public int RecursionLimit { get; set; }
        public int MaxSerializationDepth { get; set; }
    
        public override void ExecuteResult(ControllerContext context)
        {
          if (context == null)
          {
            throw new ArgumentNullException("context");
          }
    
          if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
              String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
          {
            throw new InvalidOperationException(JsonRequest_GetNotAllowed);
          }
    
          var response = context.HttpContext.Response;
    
          if (!String.IsNullOrEmpty(ContentType))
          {
            response.ContentType = ContentType;
          }
          else
          {
            response.ContentType = "application/json";
          }
    
          if (ContentEncoding != null)
          {
            response.ContentEncoding = ContentEncoding;
          }
    
          if (Data != null)
          {
            var serializer = new JavaScriptSerializer
            {
              MaxJsonLength = MaxJsonLength,
              RecursionLimit = RecursionLimit
            };
    
            serializer.RegisterConverters(new List<JavaScriptConverter> { new EFJsonConverter(MaxSerializationDepth) });
    
            response.Write(serializer.Serialize(Data));
          }
        }
