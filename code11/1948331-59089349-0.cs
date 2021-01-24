c#
using System;
using System.Security.Cryptography;
using System.Text;
public class Program
{
    public static void Main()
    {
		var bytes = Encoding.Unicode.GetBytes("1234567");
		var saltBytes = Convert.FromBase64String("U2zdbUmZXCeOLs0OuS9bhg==");
		byte[] inArray;
		var hashAlgorithm = HashAlgorithm.Create("HMACSHA256");
		var algorithm = hashAlgorithm as KeyedHashAlgorithm;
                    var keyedHashAlgorithm = algorithm;
                    if (keyedHashAlgorithm.Key.Length == saltBytes.Length)
                    {
                        //if the salt bytes is the required key length for the algorithm, use it as-is
                        keyedHashAlgorithm.Key = saltBytes;
						Console.WriteLine("length is ok");
                    }
                    else if (keyedHashAlgorithm.Key.Length < saltBytes.Length)
                    {
                        //if the salt bytes is too long for the required key length for the algorithm, reduce it
                        var numArray2 = new byte[keyedHashAlgorithm.Key.Length];
                        Buffer.BlockCopy(saltBytes, 0, numArray2, 0, numArray2.Length);
                        keyedHashAlgorithm.Key = numArray2;
						Console.WriteLine("salt byte to long");
                    }
                    else
                    {
                        //if the salt bytes is too short for the required key length for the algorithm, extend it
                        Console.WriteLine("salt byte to short");
						var numArray2 = new byte[keyedHashAlgorithm.Key.Length];
                        var dstOffset = 0;
                        while (dstOffset < numArray2.Length)
                        {
                            var count = Math.Min(saltBytes.Length, numArray2.Length - dstOffset);
                            Buffer.BlockCopy(saltBytes, 0, numArray2, dstOffset, count);
                            dstOffset += count;
                        }
                        keyedHashAlgorithm.Key = numArray2;
                    }
                    inArray = keyedHashAlgorithm.ComputeHash(bytes);
         
		var hash = Convert.ToBase64String(inArray);
		Console.WriteLine(hash);		
        var base64Hash = "7hQ60TTq0ZiT/z+eu4bdzpmBcp5uYa70ZDxQPncEG0c=";
            if (hash == base64Hash)
            {
                Console.WriteLine("Success! Both hashes match!");
            }
            else
            {
                Console.WriteLine("Passwords do not match.");
            }
	}
}
