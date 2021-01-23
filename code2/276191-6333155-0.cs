    // arrange
		var passwordMailer = MockRepository.GeneratePartialMock<PasswordMailer>();
		passwordMailer.Stub(mailer => mailer.PopulateBody(Arg<MailMessage>.Is.Anything, Arg.Is("ForgotPassword"), Arg<string>.Is.Null, Arg<Dictionary<string, string>>.Is.Null));
		// act
		var mailMessage = passwordMailer.ForgotPassword("test@example.com", "4454-8838-73773");
		// assert
		Assert.AreEqual(string.Format(Login.mailBody, "4454-8838-73773"), passwordMailer.ViewBag.Body);
		Assert.AreEqual(Login.mailSubject, mailMessage.Subject);
		Assert.AreEqual("test@example.com", mailMessage.To.First().ToString());
