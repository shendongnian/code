    [HttpGet]
    public async Task<ActionResult> GetNodes([FromQuery] string parentId)
    {
            Guid guid;
            if (Guid.TryParse(parentId, out guid))
            {
                // code when guid is not null.
                // use guid object.
            }
            else
            {
                // code when guid is null.
            }
    }
