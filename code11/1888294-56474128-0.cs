    [HttpGet]
    public ActionResult<IEnumerable<Asset>> Get()
    {
        return this._service.GetAllAssets().ToList();
    }
    [HttpGet("{id}")]
    public Asset Get(int id)
    {
        return _service.GetById(id);
    }
