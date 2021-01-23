    using System;
    using Microsoft.SqlServer.Server;
    namespace Sandbox
    {
        public static class EncryptionFunctions
        {
            /// <summary>
            /// Encrypts a string
            /// </summary>
            /// <param name="plainText"></param>
            /// <returns>varbinary</returns>
            [SqlFunction]
            public static byte[] Encrypt( string plainText )
            {
                byte[] cipherText ;
                using ( EncryptionEngine cipher = EncryptionEngine.GetInstance() )
                {
                    cipherText = cipher.Encrypt( plainText ) ;
                }
                return cipherText ;
            }
            /// <summary>
            /// Decrypts a previously encrypted varbinary
            /// </summary>
            /// <param name="cipherText"></param>
            /// <returns>string</returns>
            [SqlFunction]
            public static string Decrypt( byte[] cipherText )
            {
                string plainText ;
                using ( EncryptionEngine cipher = EncryptionEngine.GetInstance() )
                {
                    plainText = cipher.Decrypt( cipherText ) ;
                }
                return plainText ;
            }
            /// <summary>
            /// Compute the secure hash of a [plaintext] string
            /// </summary>
            /// <param name="plainText"></param>
            /// <returns> varbinary </returns>
            [SqlFunction]
            public static byte[] SecureHash( string plainText )
            {
                byte[] hash ;
                using ( EncryptionEngine cipher = EncryptionEngine.GetInstance() )
                {
                    hash = cipher.ComputeSecureHash( plainText ) ;
                }
                return hash ;
            }
            /// <summary>
            /// Convenience wrapper method to take a previously encrypted string, decrypt it and compute its secure hash
            /// </summary>
            /// <param name="cipherText"></param>
            /// <returns>varbinary</returns>
            [SqlFunction]
            public static byte[] DecryptAndHash( byte[] cipherText )
            {
                byte[] hash ;
                using ( EncryptionEngine cipher = EncryptionEngine.GetInstance() )
                {
                    hash = cipher.ComputeSecureHash( cipher.Decrypt( cipherText ) ) ;
                }
                return hash ;
            }
            /// <summary>
            /// The core encrypt/decrypt/hash engine
            /// </summary>
            private class EncryptionEngine : IDisposable
            {
                /// <summary>
                /// get an instance of this class
                /// </summary>
                /// <returns></returns>
                public static EncryptionEngine GetInstance()
                {
                    return new EncryptionEngine() ;
                }
                #region IDisposable Members
                /// <summary>
                /// Dispose of any unmanaged resources
                /// </summary>
                public void Dispose()
                {
                    throw new NotImplementedException();
                }
                #endregion
                /// <summary>
                /// Encrypt a plaintext string
                /// </summary>
                /// <param name="plainText"></param>
                /// <returns></returns>
                internal byte[] Encrypt( string plainText )
                {
                    throw new NotImplementedException();
                }
                /// <summary>
                /// Decrypt an encrypted string
                /// </summary>
                /// <param name="cipherText"></param>
                /// <returns></returns>
                internal string Decrypt( byte[] cipherText )
                {
                    throw new NotImplementedException();
                }
                /// <summary>
                /// Compute the secure hash of a string
                /// </summary>
                /// <param name="plainText"></param>
                /// <returns></returns>
                internal byte[] ComputeSecureHash( string plainText )
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
