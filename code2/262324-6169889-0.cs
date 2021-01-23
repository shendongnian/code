    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.IO;
    //Author: Doguhan Uluca
    //Website: www.deceivingarts.com
    namespace DeceivingArts.Common
    {
        public class Encryptor
        {
            private string _seed = "";
            public Encryptor(string seed)
            {
            _seed = seed;
            }
            public string Encrypt<TSymmetricAlgorithm>(string input) where TSymmetricAlgorithm : SymmetricAlgorithm, new()
            {
                var pwdBytes = Encoding.UTF8.GetBytes(_seed);
                using(TSymmetricAlgorithm sa = new TSymmetricAlgorithm())
                {
                    ICryptoTransform saEnc = sa.CreateEncryptor(pwdBytes, pwdBytes);
                    var encBytes = Encoding.UTF8.GetBytes(input);
                    var resultBytes = saEnc.TransformFinalBlock(encBytes, 0, encBytes.Length);
                    return Convert.ToBase64String(resultBytes);
                }
            }
            public string Decrypt<TSymmetricAlgorithm>(string input) where TSymmetricAlgorithm : SymmetricAlgorithm, new()
            {
                var pwdBytes = Encoding.UTF8.GetBytes(_seed);
                using(TSymmetricAlgorithm sa = new TSymmetricAlgorithm())
                {
                    ICryptoTransform saDec = sa.CreateDecryptor(pwdBytes, pwdBytes);
                    var encBytes = Convert.FromBase64String(input);
                    var resultBytes = saDec.TransformFinalBlock(encBytes, 0, encBytes.Length);
                    return Encoding.UTF8.GetString(resultBytes);
                }
            }
        }
    }
