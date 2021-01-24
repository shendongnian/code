    [HttpGet]
    public async Task<ActionResult<IEnumerable<DogDto>>> GetDogsForKennelOnDate([FromQuery]string kennelName, [FromQuery] [Date] DateTime birthDate)
    {
        ...
    }
