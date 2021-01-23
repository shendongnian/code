    public EncryptionThingy {
        PasswordEncrypter passwordEncrypter;
        public EncryptionThingy(PasswordEncrypter passwordEncrypter) {
            this.passwordEncrypter = passwordEncrypter;
        }
        // Implementations omitted
        bool tryEncryptPassword(string, RSAPublicKey, string, out string);
        bool tryEncryptPassword(SecureString, RSAPublicKey, string, out string);
    }
