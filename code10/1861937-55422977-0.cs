[Route("chargeback-all-open-ar")]
        [DeltaAuthorize(Roles.OPS_MANAGER + "," + RoleGroups.TREASURY)]
        [FireAndForget]
        [HttpPost]
        public IHttpActionResult ChargebackAllOpenAR(int clientId, [FromBody]bool isFireAndForget)
        {
            _clientService.ChargebackAllOpenAR(clientId);
            return Ok();
        }
public class FireAndForgetAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            bool isfireAndForget = (bool)actionContext.ActionArguments["isFireAndForget"];
            if (isfireAndForget)
            {
                QueueBackgroundWorker(request);
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.OK);
                return;
            }           
        }
        private void QueueBackgroundWorker(HttpRequestMessage request)
        {
            HostingEnvironment.QueueBackgroundWorkItem(clt => GetTask(request));
        }
        private async Task GetTask(HttpRequestMessage request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = request.Headers.Authorization;               
                var url = new Uri(request.RequestUri.AbsoluteUri, UriKind.Absolute);
                var param = new Dictionary<string, string>
                {
                    { "isFireAndForget", "false" }
                };
                var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(param) };
                
                await client.SendAsync(req);
            }
        }
    }
