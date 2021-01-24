    [Authorize(Policy = "UserResource")]
    public ActionResult<IActionResult> GetSomething(int resourceId)
    {
        //existing code
    }
