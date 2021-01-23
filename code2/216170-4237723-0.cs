    using System;
    using System.Security.Cryptography.X509Certificates;
    
    namespace AddCertToRootStore {
        class Program {
            static void Main (string[] args) {
                X509Store store = new X509Store (StoreName.Root,
                                                 StoreLocation.LocalMachine);
                store.Open (OpenFlags.ReadWrite);
                X509Certificate2Collection collection = new X509Certificate2Collection();
                X509Certificate2 cert = new X509Certificate2 (@"C:\Oleg\t.cer");
                byte[] encodedCert = cert.GetRawCertData();
                Console.WriteLine ("The certificate will be added to the Root...");
                store.Add (cert);
                Console.WriteLine("Verify, that the certificate are added successfully");
                Console.ReadKey ();
                Console.WriteLine ("The certificate will be removed from the Root");
                store.Remove (cert);
                store.Close ();
            }
        }
    }
