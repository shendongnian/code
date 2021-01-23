    // [HttpGet] by default
    public ActionResult Create() {}
    
    [HttpPost]
    public ActionResult Create(Skill skill, Component comp, string strSkill, int? productId) {
        if(skill == null && comp == null 
            && !string.IsNullOrWhiteSpace(strSkill) && productId.HasValue)
            // do something...
        else if(skill != null && comp != null
            && string.IsNullOrWhiteSpace(strSkill) && !productId.HasValue)
            // do something else
        else
            // do the default action
    }
