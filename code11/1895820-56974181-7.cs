    [Authorize(Policy = "UserResource")] //dont need Role name because of the RoleResourceService
    public ActionResult<IActionResult> GetSomething(int resourceId)
    {
        //existing code
    }
