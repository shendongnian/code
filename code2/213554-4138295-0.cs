    // Configure a route in Global.asax.cs that is handled by a ReportRouteHandler
    routes.Add("ReportRoute", new Route("Reports/{reportName}",
                                        new ReportRouteHandler());
    public class ReportRouteHandler : IRouteHandler {
        public IHttpHandler GetHttpHandler(RequestContext requestContext) {
            var reportName = requestContext.RouteData.Values["reportName"] as string;
            
            var webform = BuildManager
                .CreateInstanceFromVirtualPath("~/Path/To/ReportViewerWebForm.aspx",
                                               typeof(Page)) as ReportViewerWebForm;
            webform.ReportToShow = reportName;
            return webform;
        }
    }
