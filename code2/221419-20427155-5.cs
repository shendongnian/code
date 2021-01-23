     public class SecuredPasswordTests
    {
        [Test]
        public void IsHashed_AsExpected()
        {
            var securedPassword = new SecuredPassword("password");
            Assert.That(securedPassword.Hash, Is.Not.EqualTo("password"));
            Assert.That(securedPassword.Hash.Length, Is.EqualTo(256));
        }
        [Test]
        public void Generates_Unique_Salt()
        {
            var securedPassword = new SecuredPassword("password");
            var securedPassword2 = new SecuredPassword("password");
            Assert.That(securedPassword.Salt, Is.Not.Null);
            Assert.That(securedPassword2.Salt, Is.Not.Null);
            Assert.That(securedPassword.Salt, Is.Not.EqualTo(securedPassword2.Salt));
        }
        [Test]
        public void Generates_Unique_Hash()
        {
            var securedPassword = new SecuredPassword("password");
            var securedPassword2 = new SecuredPassword("password");
            Assert.That(securedPassword.Hash, Is.Not.Null);
            Assert.That(securedPassword2.Hash, Is.Not.Null);
            Assert.That(securedPassword.Hash, Is.Not.EqualTo(securedPassword2.Hash));
        }
        [Test]
        public void Verify_WhenMatching_ReturnsTrue()
        {
            var securedPassword = new SecuredPassword("password");
            var result = securedPassword.Verify("password");
            Assert.That(result, Is.True);
        }
        [Test]
        public void Verify_WhenDifferent_ReturnsFalse()
        {
            var securedPassword = new SecuredPassword("password");
            var result = securedPassword.Verify("Password");
            Assert.That(result, Is.False);
        }
        [Test]
        public void Verify_WhenRehydrated_AndMatching_ReturnsTrue()
        {
            var securedPassword = new SecuredPassword("password123");
            var rehydrated = new SecuredPassword(securedPassword.Hash, securedPassword.Salt);
            var result = rehydrated.Verify("password123");
            Assert.That(result, Is.True);
        }
        [Test]
        public void Constructor_Handles_Null_Password()
        {
            Assert.DoesNotThrow(() => new SecuredPassword(null));
        }
        [Test]
        public void Constructor_Handles_Empty_Password()
        {
            Assert.DoesNotThrow(() => new SecuredPassword(string.Empty));
        }
        [Test]
        public void Verify_Handles_Null_Password()
        {
            Assert.DoesNotThrow(() => new SecuredPassword("password").Verify(null));
        }
        [Test]
        public void Verify_Handles_Empty_Password()
        {
            Assert.DoesNotThrow(() => new SecuredPassword("password").Verify(string.Empty));
        }
        [Test]
        public void Verify_When_Null_Password_ReturnsFalse()
        {
            Assert.That(new SecuredPassword("password").Verify(null), Is.False);
        }
    }
