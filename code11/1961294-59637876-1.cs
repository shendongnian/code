        [CustomAuthorize]     
        [HttpGet]
        public HttpResponseMessage gethistogram(string entity_name, 
            string kpi_name, string chart_type, int unix_start, int 
            unix_end, string language)
        {
            var result = _definitionRepository.histogram(entity_name,kpi_name,chart_type,unix_start,unix_end,language);
            //if (result == null)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, " Entity Name? Chart Type? KPI Name?, Language? Unix Start? or Unix End?");
            //}
            //return Request.CreateResponse(HttpStatusCode.OK, result);
            if (chart_type == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid chart Type to access data");
            }
            if (kpi_name == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid KPI name to access data");
            }
            if (entity_name == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Entity name to access data");
            }
            if (kpi_name == null && chart_type == null && entity_name == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Required parameters missing to access data");
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
