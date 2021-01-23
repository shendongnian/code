    // [HttpGet] by default
    public ActionResult Create() {}
    
    [HttpPost]
    public ActionResult Create(string Skill, int ProductId) {}
    
    [HttpPost]
    public ActionResult CreateAnother(Skill Skill, Component Comp) {}
