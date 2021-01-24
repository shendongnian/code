    public async Task<IActionResult> OnGet([FromQuery] GetStatCategoryPreviewQuery query)
    {
        var result = await Mediator.Send(query);
        return new JsonResult(result);
    }
