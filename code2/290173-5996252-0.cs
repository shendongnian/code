    class BigEncryptor
    {
        delegate void EncryptFunc();
        EncryptFunc[] encryptors;
        public BigEncryptor()
        {
            encryptors = new EncryptFunc[3];
            encryptors[0] = () => { };
            encryptors[1] = () => { };
            encryptors[2] = () => { };
        }
        public void Encrypt()
        {
            for (int i = 0; i < encryptors.Length; i++)
            {
                encryptors[i]();
            }
        }
    }
