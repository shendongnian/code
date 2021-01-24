    [Route("/api/v1.0/events")]
    [HttpPost]
    public async Task<IActionResult> Events([FromBody] List<EventViewModel> viewModel)
    {
        if(viewModel == null || viewModel.Count == 0)
        {
           ModelState.AddModelError("","List can not be empty or null");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        ..............
    }
