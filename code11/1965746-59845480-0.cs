    [Authorize]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/Infra/GetEmpresas/{system}")]
        public HttpResponseMessage GetCompanies(string system)
        {
            logger.Debug("Start GetCompanies");
            HttpResponseMessage response;
            try
            {
                if (!String.IsNullOrEmpty(system))
                {
                    Companies comps = new Companies();
                    var result = comps.GetCompanies(system);
                    if (result != string.Empty)
                    {
                        if (result.ToLower().StartsWith("error"))
                        {
                            response = Request.CreateErrorResponse(HttpStatusCode.NotFound, result);
                        }
                        else
                        {
                            response = Request.CreateResponse(result);
                        }
                    }
                    else
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Company not found");
                    }
                }
                else
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "System was not provided");
                }
            }
            catch (Exception exx)
            {
                logger.Error("Error on GetCompanies");
                logger.Error(exx);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error on GetCompanies");
            }
            return response;
        }
