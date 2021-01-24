    [HttpPost]
    public ActionResult Post(MyViewModel viewModel, [FromServices] MyValidator validator) {
        ValidateFor(validator, viewModel);
        if (!IsValid) {
             //... error stuff
        }
        return Ok("Success!");
    }
