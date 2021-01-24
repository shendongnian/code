    [HttpGet("test123")]
    public ActionResult<string> Test123() {
        if(someCondition) return "String value";
        return Ok();
    }
