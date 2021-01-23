    public class Handler: IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //because we're coming into a URL that isn't being handled by DNN we need to figure out the PortalId
            SetPortalId(context.Request);
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            string localPath = context.Request.Url.LocalPath;
            if (localPath.Contains("/svc/time"))
            {
                response.Write(JsonConvert.SerializeObject(DateTime.Now));
            }
            
        }
        public bool IsReusable
        {
            get { return true; }
        }
        ///<summary>
        /// Set the portalid, taking the current request and locating which portal is being called based on this request.
        /// </summary>
        /// <param name="request">request</param>
        private void SetPortalId(HttpRequest request)
        {
            string domainName = DotNetNuke.Common.Globals.GetDomainName(request, true);
            string portalAlias = domainName.Substring(0, domainName.IndexOf("/svc"));
            PortalAliasInfo pai = PortalSettings.GetPortalAliasInfo(portalAlias);
            if (pai != null)
            {
                PortalId = pai.PortalID;
            }
        }
        protected int PortalId { get; set; }
    }
