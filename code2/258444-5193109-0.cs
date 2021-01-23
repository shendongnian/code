    var model = new ChangeSecurityQuestionModel() {
          PasswordQuestion = user.PasswordQuestion,
          QuestionList = new SelectList(membershipRepository.GetSecurityQuestionList(), "Question", "Question"),
          PasswordLength = MembershipService.MinPasswordLength;
        };
