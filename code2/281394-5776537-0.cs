    /**
    * Initialise the cipher and, possibly, the initialisation vector (IV).
    * If an IV isn't passed as part of the parameter, the IV will be all zeros.
    * An IV which is too short is handled in FIPS compliant fashion.
    *
    * @param forEncryption if true the cipher is initialised for
    *  encryption, if false for decryption.
    * @param param the key and other data required by the cipher.
    * @exception ArgumentException if the parameters argument is
    * inappropriate.
    */
    public void Init(
        bool forEncryption,
        ICipherParameters parameters)
    {
        this.encrypting = forEncryption;
        if (parameters is ParametersWithIV)
        {
            ParametersWithIV ivParam = (ParametersWithIV) parameters;
            byte[] iv = ivParam.GetIV();
            int diff = IV.Length - iv.Length;
            Array.Copy(iv, 0, IV, diff, iv.Length);
            Array.Clear(IV, 0, diff);
            parameters = ivParam.Parameters;
        }
        Reset();
        cipher.Init(true, parameters);
    }
