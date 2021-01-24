    [HttpPatch("profile")]
    public async Task<IActionResult> Update([FromBody]JsonPatchDocument<User> userPatch)
    {
        string[] validFields = new[] { "name" };
        if (userPatch.Operations.Where(o => !validFields.Contains(o.path)).Count() > 0)
        {
            // invalid field
        }
