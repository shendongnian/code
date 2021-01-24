        [HttpGet("GetMyGreatData/{patientId}")]
        [ValidatePatient]
        public async Task<ActionResult<ServiceResponse<IEnumerable<MyGreatModel>>>> GetMyGreatData(
        [FromRoute] int patientId, int offset = 0, int limit = 0)
        {
            //method details...
        }
        [HttpGet("GetMyGreatData/{patientId}")]
        [ValidatePatient]
        public async Task<ActionResult<ServiceResponse<IEnumerable<MyGreatModel>>>> GetMyGreatData( 
        [FromRoute] int patientId, 
        [FromQuery] DateTimeOffset? startdate = null,
        [FromQuery] DateTimeOffset? endDate = null,
        int offset = 0,
        int limit = 0)
        {
            //method details...
        }
