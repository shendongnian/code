[Route("chargeback-all-open-ar-async")]
        [DeltaAuthorize(Roles.OPS_MANAGER + "," + RoleGroups.TREASURY)]
        [HttpPost]
        public IHttpActionResult ChargebackAllOpenARAsync(int clientId)
        {
            _clientService.ChargebackAllOpenAR(clientId);
            return Ok();
        }
        [Route("chargeback-all-open-ar")]
        [DeltaAuthorize(Roles.OPS_MANAGER + "," + RoleGroups.TREASURY)]
        [HttpPost]
        public IHttpActionResult ChargebackAllOpenAR(int clientId)
        {
            HostingEnvironment.QueueBackgroundWorkItem(clt => ChargebackAllOpenARTask(Request, clientId));
            return Ok();
        }
        private async Task ChargebackAllOpenARTask(HttpRequestMessage request, int clientId)
        {
            //Calls ChargebackAllOpenARAsync method
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = request.Headers.Authorization;
                var url = new Uri(request.RequestUri.AbsoluteUri + "-async", UriKind.Absolute);
                await client.PostAsync(url, new StringContent(string.Empty));
            }
        }
