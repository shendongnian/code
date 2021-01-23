    public abstract class PdfTemplateHandler : IHttpHandler
    {
        public virtual bool DownloadAsAttachment
        {
            get
            {
                return true;
            }
        }
    
        protected virtual TimeSpan PdfTemplateCacheDuration
        {
            get
            {
                return TimeSpan.FromMinutes(30);
            }
        }
    
        protected virtual string PdfTemplateCacheKey
        {
            get
            {
                return string.Format("__PDF_Template[{0}]", TemplatePath);
            }
        }
    
        protected string DownloadFileName { get; set; }
    
        protected HttpContext Context { get; private set; }
    
        protected HttpResponse Response { get; private set; }
    
        protected HttpRequest Request { get; private set; }
    
        #region IHttpHandler Members
    
        public bool IsReusable
        {
            get { return false; }
        }
    
        public void ProcessRequest(HttpContext context)
        {
    
            Context = context;
            Response = context.Response;
            Request = context.Request;
    
            try
            {
                LoadDataInternal();
            }
            catch (ThreadAbortException)
            {
                // no-op
            }
            catch (Exception ex) {            
                Logger.LogError(ex);
                Response.Write("Error");
                Response.End();
            }
    
            Response.BufferOutput = true;
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
    
            if (DownloadAsAttachment)
            {
                Response.AddHeader("Content-Disposition", "attachment; filename=" +
                    (string.IsNullOrEmpty(DownloadFileName) ? context.Session.SessionID + ".pdf" : DownloadFileName));
            }
    
            PdfStamper pst = null;
            try
            {
                PdfReader reader = new PdfReader(GetTemplateBytes());
                pst = new PdfStamper(reader, Response.OutputStream);
                var acroFields = pst.AcroFields;
                
                pst.FormFlattening = true;
                pst.FreeTextFlattening = true;
                pst.SetFullCompression();
    
                SetFieldsInternal(acroFields);
                pst.Close();
            }
            finally
            {
                if (pst != null)
                    pst.Close();
            }
        }
    
        #endregion
    
        #region Abstract Members for overriding and providing functionality
    
        protected abstract string TemplatePath { get; }
    
        protected abstract void LoadDataInternal();
    
        protected abstract void SetFieldsInternal(AcroFields acroFields);
    
        #endregion
    
        protected virtual byte[] GetTemplateBytes()
        {
            var data = Context.Cache[PdfTemplateCacheKey] as byte[];
            if (data == null)
            {
                data = File.ReadAllBytes(Context.Server.MapPath(TemplatePath));
                Context.Cache.Insert(PdfTemplateCacheKey, data,
                    null, DateTime.Now.Add(PdfTemplateCacheDuration), Cache.NoSlidingExpiration);
            }
            return data;
        }
    
    }
