        [TestMethod]
        public void Test_SaltGeneration()
        {
            var password = "48F3A112-F574-4B25-B226-CE97888FCBCB";
            var firstResult = PasswordCrypting(password);
            var secondResult = PasswordDecrypting(password, firstResult.salt);
            Assert.IsTrue(firstResult.hash.Equals(secondResult));
        }
        public (string hash, string salt) PasswordCrypting(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return (hashed, Convert.ToBase64String(salt));
        }
        public string PasswordDecrypting(string password, string salt )
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
