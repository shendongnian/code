    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
    using System.Web.Helpers;
    using System.IO;
    
    
    namespace Utility
    {
        public class PasswordManager
        {
            #region [ Public Methods ]
    
            /// <summary>
            /// AES 256 Encryption 
            /// </summary>
            /// <param name="inputText">string InputText</param>
            /// <returns>string EncryptedText</returns>
            public string Encryption(string InputText)
            {
                string EncryptedText = string.Empty;
                try
                {
                    if (string.IsNullOrEmpty(InputText))
                    {
                        throw new ArgumentException(Keys.NullInputEncryptionString);
                    }
                    else
                    {
                        EncryptedText = EncryptToBase64(InputText);
                    }
                }
                catch (Exception ExceptionObject)
                {
                    throw;
                }
                return EncryptedText;
            }
    
            /// <summary>
            /// AES 256 Decryption 
            /// </summary>
            /// <param name="encryptedText">string encryptedText</param>
            /// <returns>string DecryptedText</returns>
            public string Decryption(string EncryptedText)
            {
                string DecryptedText = string.Empty;
                try
                {
                    if (string.IsNullOrEmpty(EncryptedText))
                    {
                        throw new ArgumentException(Keys.NullInputDecryptionString);
                    }
                    DecryptedText = DecryptFromBase64(EncryptedText);
                }
                catch (Exception ExceptionObject)
                {
                    throw;
                }
                return DecryptedText;
            }
    
            #endregion
    
            #region [ Private Methods ]
    
            /// <summary>
            /// Encrypt string with AES-256 by using password.
            /// </summary>
            /// <param name="password">Password string.</param>
            /// <param name="s">String to encrypt.</param>
            /// <returns>Encrypted Base64 string.</returns>
            private static string EncryptToBase64(string InputText)
            {
                // Turn input strings into a byte array.
                byte[] InputByteArray = System.Text.Encoding.Unicode.GetBytes(InputText);
                // Get encrypted bytes.
                byte[] EncryptedBytes = EncryptValue(InputByteArray);
                // Convert encrypted data into a base64-encoded string.
                string Base64String = System.Convert.ToBase64String(EncryptedBytes);
                // Return encrypted string.
                return Base64String;
            }
    
            /// <summary>
            /// Decrypt string with AES-256 by using password key.
            /// </summary>
            /// <param name="password">String password.</param>
            /// <param name="base64String">Encrypted Base64 string.</param>
            /// <returns>Decrypted string.</returns>
            private static string DecryptFromBase64(string EncryptedText)
            {
                // Convert Base64 string into a byte array. 
                byte[] EncryptedBytes = System.Convert.FromBase64String(EncryptedText);
                byte[] DecryptedBytes = DecryptValue(EncryptedBytes);
                // Convert decrypted data into a string. 
                string OutputString = System.Text.Encoding.Unicode.GetString(DecryptedBytes, 0, DecryptedBytes.Length);
                // Return decrypted string.   
                return OutputString;
            }
    
            /// <summary>
            /// Encrypt string with AES-256 by using password.
            /// </summary>
            /// <param name="password">String password.</param>
            /// <param name="bytes">Bytes to encrypt.</param>
            /// <returns>Encrypted bytes.</returns>
            private static byte[] EncryptValue(byte[] Bytes)
            {
                // Create a encryptor.
                ICryptoTransform Encryptor = GetTransform(true);
                // Return encrypted bytes.
                return CipherStreamWrite(Encryptor, Bytes);
            }
    
            /// <summary>
            /// Decrypt string with AES-256 by using password key.
            /// </summary>
            /// <param name="password">String password.</param>
            /// <param name="encryptedBytes">Encrypted bytes.</param>
            /// <returns>Decrypted bytes.</returns>
            private static byte[] DecryptValue(byte[] Bytes)
            {
                // Create a encryptor.
                ICryptoTransform Decryptor = GetTransform(false);
                // Return encrypted bytes.
                return CipherStreamWrite(Decryptor, Bytes);
            }
    
            /// <summary>
            /// Cryptographic transformation
            /// </summary>
            /// <param name="password"></param>
            /// <param name="encrypt"></param>
            /// <returns></returns>
            private static ICryptoTransform GetTransform(bool Encrypt)
            {
                // Create an instance of the Rihndael class. 
                RijndaelManaged Cipher = new System.Security.Cryptography.RijndaelManaged();
    
                // Calculate salt to make it harder to guess key by using a dictionary attack.
                byte[] Salt = SaltFromPassword();
    
                // Generate Secret Key from the password and salt.
                // Note: Set number of iterations to 10 in order for JavaScript example to work faster.
                Rfc2898DeriveBytes SecretKey = new System.Security.Cryptography.Rfc2898DeriveBytes(Keys.KEY, Salt, 10);
    
                // Create a encryptor from the existing SecretKey bytes by using
                // 32 bytes (256 bits) for the secret key and
                // 16 bytes (128 bits) for the initialization vector (IV).
                byte[] SecretKeyBytes = SecretKey.GetBytes(32);
                byte[] InitializationVectorBytes = SecretKey.GetBytes(16);
                ICryptoTransform Cryptor = null;
                if (Encrypt)
                {
                    Cryptor = Cipher.CreateEncryptor(SecretKeyBytes, InitializationVectorBytes);
                }
                else
                {
                    Cryptor = Cipher.CreateDecryptor(SecretKeyBytes, InitializationVectorBytes);
                }
                return Cryptor;
            }
    
            /// <summary>
            /// Encrypt/Decrypt with Write method.
            /// </summary>
            /// <param name="cryptor"></param>
            /// <param name="input"></param>
            /// <returns></returns>
            private static byte[] CipherStreamWrite(ICryptoTransform Cryptor, byte[] InputBytes)
            {
                try
                {
                    byte[] InputBuffer = new byte[InputBytes.Length];
    
                    // Copy data bytes to input buffer.
                    Buffer.BlockCopy(InputBytes, 0, InputBuffer, 0, InputBuffer.Length);
    
                    // Create a MemoryStream to hold the output bytes.
                    MemoryStream MemoryStream = new MemoryStream();
    
                    // Create a CryptoStream through which we are going to be processing our data.
                    CryptoStreamMode CryptoStreamMode;
                    CryptoStreamMode = CryptoStreamMode.Write;
                    CryptoStream CryptoStream;
                    CryptoStream = new CryptoStream(MemoryStream, Cryptor, CryptoStreamMode);
    
                    // Start the crypting process.
                    CryptoStream.Write(InputBuffer, 0, InputBuffer.Length);
    
                    // Finish crypting.
                    CryptoStream.FlushFinalBlock();
    
                    // Convert data from a memoryStream into a byte array.
                    byte[] OutputBuffer = MemoryStream.ToArray();
    
                    // Close both streams.
                    MemoryStream.Close();
                    CryptoStream.Close();
    
                    return OutputBuffer;
                }
                catch (Exception ExceptionObject)
                {
                    throw;
                }
            }
    
            /// <summary>
            /// Generate salt from password.
            /// </summary>
            /// <param name="password">Password string.</param>
            /// <returns>Salt bytes.</returns>
            private static byte[] SaltFromPassword()
            {
                try
                {
                    byte[] KeyBytes = System.Text.Encoding.UTF8.GetBytes(Keys.KEY);
                    HMACSHA1 HashFunctionSha1;
                    HashFunctionSha1 = new HMACSHA1(KeyBytes);
                    byte[] Salt = HashFunctionSha1.ComputeHash(KeyBytes);
                    return Salt;
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            #endregion
        }
    
        static class Keys
        {
            #region [ Private Fields ]
            private static string nullInputEncryptionString = "Encryption Failed : Invalid / Empty Input String";
            private static string nullInputDecryptionString = "Decryption Failed : Invalid / Empty Input String";
            private static string key = "Test@2013Rebuild$Encrypt";
            #endregion
    
            #region [ public properties ]
            public static string NullInputEncryptionString { get { return nullInputEncryptionString; } }
            public static string NullInputDecryptionString { get { return nullInputDecryptionString; } }
            public static string KEY { get { return key; } }
            #endregion
        }
    }
    
    When Calling from your Servics
    
    
    
     /// <summary>
            /// Validate the password hash
            /// </summary>
            /// <param name="model"></param>
            /// <param name="entity"></param>
            public void ValidatePasswordHashForUser(UserModels model, string entity)
            {
                string passwordHash = string.Empty;
                try
                {
                    passwordHash = ValidatePasswordWithHash(model.Password, _objUserModel.PasswordHash);
                    model.PasswordHash = passwordHash;
                }
                catch (Exception ex)
                {
                    Logger.Error("Exception from GetSaltAndHashForUser(): " + ex.Message);
                }
            }
    
    
      /// <summary>
            /// Validate password hash
            /// </summary>
            /// <param name="password"></param>
            /// <param name="passwordHash"></param>
            /// <returns></returns>
            public string ValidatePasswordWithHash(string password, string passwordHash)
            {
                string passwordHashGenerated = string.Empty;
                passwordHashGenerated = _pwdManager.Encryption(password);
    
                return passwordHashGenerated;
            }
    
     /// <summary>
            /// Generate password hash
            /// </summary>
            /// <param name="password"></param>
            /// <returns></returns>
            public string GeneratePasswordHash(string password)
            {
                string passwordHash = string.Empty;
    
                if (!String.IsNullOrEmpty(password))
                {
                    passwordHash = _pwdManager.Encryption(password);
                }
    
                return passwordHash;
            }
