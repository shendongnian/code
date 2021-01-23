    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Contact contact)
    {
      var skipped = ModelState.Keys.Where(key => key.StartsWith(nameof(Contact.Portfolios)));
      foreach (var key in skipped)
        ModelState.Remove(key);
        //ModelState doesn't include anything about Portfolios which we're not concerned with
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      //Rest of action
    }
