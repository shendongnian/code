cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace PlayingWithAmazonS3
{
    /// <summary>
    /// this class is only responsible for calculating the final signature for creating a pre-signed Url to
    /// communicate through REST with iam service
    /// </summary>
    public class PreSignedUrlRestSignatureCal
    {
        private const string RegionSample = "us-east-1";
        private const string DateSample = "20150830";
        private const string ServiceSample = "iam";
        // it is provided as an example by AWS
        private const string SecretAccessKeySample = "wJalrXUtnFEMI/K7MDENG+bPxRfiCYEXAMPLEKEY";
        /// <summary>
        /// this method will be called in main
        /// </summary>
        public void ExecuteMethod()
        {
            var finalSignature = SigningKey();
            Console.WriteLine("Final Signature: " + finalSignature);
        }
        private string SigningKey()
        {
            // generating derived signing key
            var derivedSigningKey =
                GetSignatureKey(SecretAccessKeySample, DateSample, RegionSample, ServiceSample);
            // example signingKey provided by aws for test
            var stringToSign = "AWS4-HMAC-SHA256" + "\n" +
                               "20150830T123600Z" + "\n" +
                               "20150830/us-east-1/iam/aws4_request" + "\n" +
                               "f536975d06c0309214f805bb90ccff089219ecd68b2577efef23edd43b7e1a59";
            // generating the final signature
            var signature = HmacSha256(stringToSign, derivedSigningKey);
            // returning the hex value of the final signature
            return ByteToString(signature);
        }
        /// <summary>
        /// calculating hmac-sha256 in .Net
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private byte[] HmacSha256(string data, byte[] key)
        {
            const string algorithm = "HmacSHA256";
            var kha = KeyedHashAlgorithm.Create(algorithm);
            kha.Key = key;
            return kha.ComputeHash(Encoding.UTF8.GetBytes(data));
        }
        /// <summary>
        /// get derived signing key (not the final signature) from provided info 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dateStamp"></param>
        /// <param name="regionName"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        private byte[] GetSignatureKey(string key, string dateStamp, string regionName, string serviceName)
        {
            var kSecret = Encoding.UTF8.GetBytes(("AWS4" + key).ToCharArray());
            var kDate = HmacSha256(dateStamp, kSecret);
            var kRegion = HmacSha256(regionName, kDate);
            var kService = HmacSha256(serviceName, kRegion);
            var kSigning = HmacSha256("aws4_request", kService);
            return kSigning;
        }
        /// <summary>
        /// it returns the hex value of byte[]
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private string ByteToString(IEnumerable<byte> buffer)
        {
            var sBinary = buffer.Aggregate("", (current, buff) => current + buff.ToString("X2"));
            return sBinary.ToLower();
        }
    }
}
