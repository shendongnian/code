        [HttpGet]
        [Route("headers")]
        public ActionResult<string> Get([FromQuery] HeadersParameters parameters = null)
        {
            return JsonConvert.SerializeObject(parameters);
        }
