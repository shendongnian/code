    private async Task<IActionResult> WebWorker<TModel> (TModel model, Func<TModel, Task<IActionResult>> workToDo) {
        try {
            return await workToDo(TModel model);
        } catch (ValidationException vldEx) {
            foreach (var vldError in vldEx.Errors) {
                ModelState.AddModelError(vldError.PropertyName, vldError.ErrorMessage);
            }
            return View(model);
        }
    }
