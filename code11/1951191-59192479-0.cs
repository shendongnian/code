    class Model {
        public string Encrypted {get;set}
        [NotMapped]
        public string Decrypted {
        get { return Decrypt(Encrypted);}
       set { Encrypted = Encrypt(value);}
       }
    }
