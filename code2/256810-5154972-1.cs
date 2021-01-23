    using (FileStream fsInput = new FileStream(strInputFile, FileMode.Open, FileAccess.Read))
    {
        using (FileStream fsOutput = new FileStream(strOutputFile, FileMode.OpenOrCreate, FileAccess.Write))
        {
            CryptoStream csCryptoStream = null;
            RijndaelManaged cspRijndael = new RijndaelManaged();
            cspRijndael.BlockSize = 256;
            switch (Direction)
            {
                case CryptoAction.ActionEncrypt:
                    csCryptoStream = new CryptoStream(fsOutput, cspRijndael.CreateEncryptor(bytKey, bytIV),
                                                      CryptoStreamMode.Write);
                    break;
                case CryptoAction.ActionDecrypt:
                    csCryptoStream = new CryptoStream(fsOutput, cspRijndael.CreateDecryptor(bytKey, bytIV),
                                                      CryptoStreamMode.Write);
                    break;
            }
            fsInput.CopyTo(csCryptoStream);
            csCryptoStream.Close();
        }
    }
    pRet = true;
