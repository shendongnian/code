    [HttpGet]
    [ProducesResponseType(typeof(OtherModel[]), 200)]             // <--- This line
    public ActionResult<List<ActualModel>> Get()
    {
        return new List<ActualModel>()
        {
            new ActualModel { StringValue1 = "SomeString" },
            new ActualModel { StringValue1 = "MoreString" }
        };
    }
