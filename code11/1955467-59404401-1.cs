    namespace Yovav.Security
    {
    	using System;
    	using System.Diagnostics;
    	using System.IO;
    	using System.Security.Cryptography;
    
    	/// <summary>
    	/// AES wrapper implementation by Yovav Gad using the AesManaged algorithm.
    	/// <para>http://en.wikipedia.org/wiki/Advanced_Encryption_Standard</para>
    	/// </summary>
    	public sealed class AesWrapper
    	{
    		/// <summary>
    		/// Create a SymmetricAlgorithm using AesManaged
    		/// </summary>
    		/// <param name="key">Byte array representing the key values, please note, 
    		/// for better performance, use Convert.FromBase64String() outside of this method.</param>
    		/// <param name="blockSize">BlockSize, default is 128</param>
    		/// <param name="paddingMode">PaddingMode, default is PaddingMode.Zeros</param>
    		/// <param name="cipherMode">CipherMode, default is CipherMode.CBC</param>
    		/// <returns></returns>
    		private static SymmetricAlgorithm CreateCrypto(
    			byte[] key, 
    			int blockSize = 128,
    			PaddingMode paddingMode = PaddingMode.Zeros,
    			CipherMode cipherMode = CipherMode.CBC
    			)
    		{
    			SymmetricAlgorithm crypto = new AesManaged
    			{
    				Key = key,
    				Mode = cipherMode,
    				Padding = paddingMode,
    				BlockSize = blockSize
    			};
    
    			crypto.IV = new byte[crypto.IV.Length];
    
    			return (crypto);
    		}
    
    		/// <summary>
    		/// Decrypt an encrypted string using a specific key.
    		/// </summary>
    		/// <param name="str">String to decrypt</param>
    		/// <param name="key">Byte array representing the key values, please note, 
    		/// for better performance, use Convert.FromBase64String() outside of this method.</param>
    		/// <param name="blockSize">BlockSize, default is 128</param>
    		/// <param name="paddingMode">PaddingMode, default is PaddingMode.Zeros</param>
    		/// <param name="cipherMode">CipherMode, default is CipherMode.CBC</param>
    		/// <returns></returns>
    		[DebuggerStepThrough()]
    		public static string Decrypt(
    			string str, 
    			byte[] key,
    			int blockSize = 128,
    			PaddingMode paddingMode = PaddingMode.Zeros,
    			CipherMode cipherMode = CipherMode.CBC
    			)
    		{
    			if (str == null || str.Length < 1 ||
    				key == null || key.Length < 1)
    			{
    				return null;
    			}
    
    			var result = string.Empty;
    
    			using (var crypto = CreateCrypto(key, blockSize, paddingMode, cipherMode))
    			{
    				var strCombined = Convert.FromBase64String(str);
    				var iv = new byte[crypto.BlockSize / 8];
    				var cipherText = new byte[strCombined.Length - iv.Length];
    				Array.Copy(strCombined, iv, iv.Length);
    				Array.Copy(strCombined, iv.Length, cipherText, 0, cipherText.Length);
    
    				crypto.IV = iv;
    				ICryptoTransform decryptor = crypto.CreateDecryptor(key, iv);
    
    				using (var msDecrypt = new MemoryStream(cipherText))
    				{
    					using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
    					{
    						using (var srDecrypt = new StreamReader(csDecrypt))
    						{
    							result = srDecrypt.ReadToEnd();
    						}
    					}
    				}
    
    				if (paddingMode == PaddingMode.Zeros)
    					{
    						// This is required when using PaddingMode.Zeros for values shorted than the block size.
    						// Note: using .TrimEnd('\0') to remove nulls and not .TrimEnd("\0") to allow the string values.
    						result = result.TrimEnd('\0');
    					}
    
    				return (result);
    			}
    		}
    
    		/// <summary>
    		/// Encrypt a string using a specific key.
    		/// </summary>
    		/// <param name="str">String to encrypt</param>
    		/// <param name="key">Byte array representing the key values, please note, 
    		/// for better performance, use Convert.FromBase64String() outside of this method.</param>
    		/// <param name="blockSize">BlockSize, default is 128</param>
    		/// <param name="paddingMode">PaddingMode, default is PaddingMode.Zeros</param>
    		/// <param name="cipherMode">CipherMode, default is CipherMode.CBC</param>
    		/// <returns></returns>
    		[DebuggerStepThrough()]
    		public static string Encrypt(
    			string str,
    			byte[] key,
    			int blockSize = 128,
    			PaddingMode paddingMode = PaddingMode.Zeros,
    			CipherMode cipherMode = CipherMode.CBC
    			)
    		{
    			if (str == null || str.Length < 1 ||
    				key == null || key.Length < 1)
    			{
    				return null;
    			}
    
    			byte[] encryptedData;
    
    			using (SymmetricAlgorithm crypto = CreateCrypto(key, blockSize, paddingMode, cipherMode))
    			{
    				byte[] data;
    				crypto.GenerateIV();
    				var iv = crypto.IV;
    				var encryptor = crypto.CreateEncryptor(key, iv);
    
    				using (MemoryStream ms = new MemoryStream())
    				{
    					using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
    					{
    						using (StreamWriter sw = new StreamWriter(cs))
    						{
    							sw.Write(str);
    						}
    
    						data = ms.ToArray();
    					}
    				}
    
    				// Combine the iv (salt) and the encrypted data
    				encryptedData = new byte[iv.Length + data.Length];
    				Array.Copy(iv, 0, encryptedData, 0, iv.Length);
    				Array.Copy(data, 0, encryptedData, iv.Length, data.Length);
    			}
    
    			return Convert.ToBase64String(encryptedData);
    		}
    	}
    }
