    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    
                store.Open(OpenFlags.ReadOnly);
    
                foreach (var cert in store.Certificates)
                {
                    string desc = cert.GetNameInfo(X509NameType.SimpleName, true);
                    if (desc.Contains("WISeKey"))
                    {
                        RSA pk = cert.GetRSAPrivateKey();                    
                        byte[] buffer = Encoding.Default.GetBytes("Hello World ... !");
                        byte[] signature = pk.SignData(buffer, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                        System.Console.WriteLine(BitConverter.ToString(signature));                  
                        
                        break;
                    }                
                }
                Console.ReadLine();
            }
        }
    }
