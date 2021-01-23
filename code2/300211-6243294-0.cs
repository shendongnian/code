    public class Encrypt
    {
        private byte[] skey;
        private byte[] iv;
        private ParametersWithIV skey_spec;
        public Encrypt()
        {
        }
        public void initAES()
        {
            RijndaelManaged myAES = new RijndaelManaged();
            myAES.Padding = PaddingMode.PKCS7;
            myAES.Mode = CipherMode.CBC;
            myAES.KeySize = 256;
            myAES.BlockSize = 128;
            myAES.GenerateIV();
            myAES.GenerateKey();
            skey = myAES.Key;
            iv = myAES.IV;
    
            skey_spec = new ParametersWithIV(new KeyParameter(skey), iv);
        }
    }
