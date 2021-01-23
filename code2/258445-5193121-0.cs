    [Authorize]
    public ActionResult ChangeSecurityQuestion() {
        var user = Membership.GetUser();
        if (user != null) {
            var model = new ChangeSecurityQuestionModel() {
                PasswordQuestion = user.PasswordQuestion,
                QuestionList = new SelectList(membershipRepository.GetSecurityQuestionList(), "Question", "Question"),
                PasswordLength = MembershipService.MinPasswordLength
            };
            return View(model);
        }
        // user not found
        return RedirectToAction("Index");
    }
    [Authorize]
    [HttpPost]
    public ActionResult ChangeSecurityQuestion(ChangeSecurityQuestionModel model) {
        if (ModelState.IsValid) {
            var user = Membership.GetUser();
            if (user != null) {
                if (user.ChangePasswordQuestionAndAnswer(model.Password, model.PasswordQuestion, model.PasswordAnswer)) {
                    return View("ChangeQuestionSuccess");
                } else {
                    ModelState.AddModelError("", "The password is incorrect.");
                }
            }
        }
        // If we got this far, something failed, redisplay form
        model.QuestionList = new SelectList(membershipRepository.GetSecurityQuestionList(), "Question", "Question");
        model.PasswordLength = MembershipService.MinPasswordLength;
        return View(model);
    }
