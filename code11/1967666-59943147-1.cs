    [Route("/api/v1.0/events")]
    [HttpPost]
    public async Task<IActionResult> Events([ModelBinder(BinderType = typeof(NotEmptyListOfViewModels))]List<EventViewModel> viewModel)
    {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }
         return Ok();
    }
