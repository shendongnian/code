    public ActionResult<Round> Get(string id)
    {
        var result = this._roundsService.Get(id);
        if (result != null)
            return result;
        return NotFound();
    }
