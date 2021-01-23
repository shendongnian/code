    public class PasswordResetEmailCreatorSpecs
    {
        public class given_a_registered_user : SpecsFor<PasswordResetEmailCreator>
        {
            private string _emailAddress;
            private MailMessage _email;
            protected override void Given()
            {
                _emailAddress = "user@example.org";
            }
            protected override void When()
            {
                _email = SUT.Create(_emailAddress);
            }
            [Test]
            public void then_the_body_must_contain_the_reset_uri()
            {
                _email.Body.ShouldContain("/Password/Reset/");
            }
            [Test]
            public void then_the_email_must_be_for_the_user()
            {
                _email.To[0].Address.ShouldEqual(_emailAddress);
            }
            [Test]
            public void then_the_subject_must_be_the_expected()
            {
                _email.Subject.ShouldEqual("Your email reset link");
            }
        }
    }
