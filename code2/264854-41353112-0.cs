        [AllowAnonymous]
        [HttpGet]
        [ActionName("serverusage")]
        public HttpResponseMessage serverusage()
        {
            try
            {
                
                PerformanceCounter cpuCounter;
                if (HttpContext.Current.Application["cpuobj"] == null)
                {
                    cpuCounter = new PerformanceCounter();
                    cpuCounter.CategoryName = "Processor";
                    cpuCounter.CounterName = "% Processor Time";
                    cpuCounter.InstanceName = "_Total";
                    HttpContext.Current.Application["cpuobj"] = cpuCounter;
                }
                else
                {
                    cpuCounter = HttpContext.Current.Application["cpuobj"] as PerformanceCounter;
                }
                JToken json;
                try
                {
                    json = JObject.Parse("{ 'usage' : '" + HttpContext.Current.Application["cpu"] + "'}");
                }
                catch
                {
                    json = JObject.Parse("{ 'usage' : '" + 0 + "'}");
                }
                    HttpContext.Current.Application["cpu"] = cpuCounter.NextValue();
                
                var response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
                response.Content = new JsonContent(json);
                return response;
                
            }
            catch (Exception e)
            {
                var response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                JToken json = JObject.Parse("{ 'problem' : '" + e.Message + "'}");
                response.Content = new JsonContent(json);
                return response;
            }
            
        }
    }
