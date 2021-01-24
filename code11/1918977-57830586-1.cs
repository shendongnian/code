     [HttpPost]
     public async Task<IActionResult> Create(CreateAccountViewModel model) {
         return await WebWorker<CreateAccountViewModel>(model,
              m => {
                 Mediator.Send(_mapper.Map<CreateAccountCommand>(m));
                 return RedirectToAction("Index");
             });
     }
