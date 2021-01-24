    [HttpGet]
    public async Task<ActionResult<IEnumerable<DogDto>>> GetDogsForKennelOnDate([FromQuery]string kennelName, [FromQuery]DateTime birthDate)
    {
        DateTime birthDateDate = birthDate.Date;
    }
