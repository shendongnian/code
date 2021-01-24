    [HttpGet]
    [MyValidation]
    public IEnumerable<Whatever> Get(DateTime from, DateTime to)
    {
        // Here ModelState.IsValid is true
    }
