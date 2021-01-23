    [HttpPost]
        public ActionResult Create(CreateUserModel model) {
            // Verify user name for clients who have JavaScript disabled
            if (_repository.UserExists(model.UserName)) {
                ModelState.AddModelError("UserName", ValidationController.GetAltName(model.UserName, _repository));
                return View("Create", model);
            }
