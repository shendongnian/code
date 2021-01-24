    private static class NCryptInterop
    {
        private struct BCRYPT_PKCS1_PADDING_INFO
        {
            internal IntPtr pszAlgId;
        }
        [Flags]
        private enum NCryptSignFlags
        {
            BCRYPT_PAD_PKCS1 = 2,
        }
        [DllImport("ncrypt.dll")]
        private static extern int NCryptSignHash(
            SafeNCryptKeyHandle hKey,
            ref BCRYPT_PKCS1_PADDING_INFO padding,
            ref byte pbHashValue,
            int cbHashValue,
            ref byte pbSignature,
            int cbSignature,
            out int cbResult,
            NCryptSignFlags dwFlags);
        internal static byte[] SignHashRaw(CngKey key, byte[] hash, int keySize)
        {
            int keySizeBytes = keySize / 8;
            byte[] signature = new byte[keySizeBytes];
            // The Handle property returns a new object each time.
            using (SafeNCryptKeyHandle keyHandle = key.Handle)
            {
                // Leave pszAlgId NULL to "raw sign"
                BCRYPT_PKCS1_PADDING_INFO paddingInfo = new BCRYPT_PKCS1_PADDING_INFO();
                int result = NCryptSignHash(
                    keyHandle,
                    ref paddingInfo,
                    ref hash[0],
                    hash.Length,
                    ref signature[0],
                    signature.Length,
                    out int cbResult,
                    NCryptSignFlags.BCRYPT_PAD_PKCS1);
                if (result != 0)
                {
                    throw new CryptographicException(result);
                }
                if (cbResult != signature.Length)
                {
                    throw new InvalidOperationException();
                }
                return signature;
            }
        }
    }
