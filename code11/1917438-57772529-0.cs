        [HttpGet]
        [Route("headers")]
        public ActionResult<string> Get([FromHeader] HeadersParameters parameters = null)
        {
            return JsonConvert.SerializeObject(parameters);
        }
