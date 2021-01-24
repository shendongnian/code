    private async Task<IActionResult> CreateBase(CreateAccountViewModel model, string action)
    {
        try
        {
            await Mediator.Send(_mapper.Map<CreateAccountCommand>(model));
            return RedirectToAction(action);
        }
        catch (ValidationException vldEx)
        {
            foreach (var vldError in vldEx.Errors)
            {
                ModelState.AddModelError(vldError.PropertyName, vldError.ErrorMessage);
            }
            return View(model);
        }
    }
