public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            log4net.ThreadContext.Properties["addr"] = HttpContext.Current.Request.UserHostAddress;
            log4net.ThreadContext.Properties["Hostname"] = Dns.GetHostName().ToString();
            log4net.ThreadContext.Properties["PCName"] = Dns.GetHostAddresses(Environment.MachineName)[0].ToString();
            string RequestMethod = context.Request.Method.Method;
            dynamic actionContext = context.ActionContext;
            dynamic ControllerInfo = actionContext.ControllerContext.Controller;
            string RequestName = ControllerInfo.Url.Request.RequestUri.LocalPath.ToString().Replace("/api/", "").Replace("/VVFAPI", "");
            Log.Error("Error in " + RequestName +" "+ RequestMethod+ " Request - " + context.Exception.Message, context.Exception);
            NewRelic.Api.Agent.NewRelic.NoticeError("Error in " + RequestName + " " + RequestMethod + " Request - " + context.Exception.Message, null);
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Internal Server Error. Please Contact Admin."),
                ReasonPhrase = "Critical Exception."
            };
            context.Response = msg;
        }
    }
Also, I changed my controller accordingly
        [HttpPost]
        [Authorize]
        [ValidateModel]
        [MyExceptionFilter]
        [Route("CheckProgramOwner")]
        public async Task<IHttpActionResult> CheckProgramOwner([FromBody] CheckProgramOwner _data)
        {
            Log.Info("CheckProgramOwner POST Request");
            using (var db = new VisualVoiceFlowEntities())
            {
                var Result = await db.VVF_ScriptFlow.Where(s => s.ProgramId == _data.ProgramId).OrderByDescending(s => s.ID).FirstOrDefaultAsync();
                if (Result == null)
                {
                    Log.Error("Error in CheckProgramOwner POST Request - " + "ProgramId not found");
                    return Content(HttpStatusCode.BadRequest, "ProgramId not found");
                }
                string CurrentOwner = Result.ReadBy.ToString();
                return Ok(CurrentOwner);
            }
        }
