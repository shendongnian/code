    private Crypto()
    {
        _myAes = new AesManaged();
        _myAes.Padding = PaddingMode.none; //rather than _myAes.Padding = PaddingMode.PKCS7;
        _myAes.KeySize = 128;
        _myAes.Key = Enumerable.Repeat((byte)'B', 128 / 8).ToArray();
        _myAes.IV = Enumerable.Repeat((byte)'C', 128 / 8).ToArray();
    }
