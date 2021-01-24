        [EnableQuery]
        [DecodeFilter]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAllProcesses());
        }
