    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Diagnostics;
    public class SSLCertificateCreator
    {
        public static string RunDosCommand(string Cmd, string Arguments)
        {//Executes a Dos command in the current directory and then returns the result
            string TestMessageText = "";
            string filePath = Environment.CurrentDirectory;
            ProcessStartInfo pi = new ProcessStartInfo()
            {
                FileName = filePath + "\\" + Cmd,
                Arguments = Arguments + " ",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = false
            };
            try
            {
                using (Process p = Process.Start(pi))
                {
                    p.WaitForExit();
                    TestMessageText = p.StandardOutput.ReadToEnd();
                    return TestMessageText;
                }
            }
            catch (Exception Ex)
            {
                return "ERROR :" +Ex.Message;
            }
        }
        public static bool MakeCACertificate(string RootCertificateName, string FriendlyName)
        {//Make a CA certificate but only if we don't already have one and then sets the friendly name
            if (FindCertificate("Root", RootCertificateName, OpenFlags.ReadOnly) != null) return false; //We already have this root certificate
            string Arguments="-pe -n \"CN=" + RootCertificateName + "\" -ss Root -sr CurrentUser -a sha1 -sky signature -r \"" + RootCertificateName + ".cer\" -m 12";
            string Result=RunDosCommand("makecert", Arguments);
            X509Certificate2 Cert = FindCertificate("Root", RootCertificateName, OpenFlags.ReadWrite);
            if (Cert == null || !Result.ToLower().StartsWith("succeeded")) return false;
            Cert.FriendlyName = FriendlyName;
            return true;
        }
        public static bool MakeSignedCertificate(string RootCertificateName, string CertificateName, string FriendlyName)
        {//Makes a signed certificate but only if we have the root certificate and then sets the friendly name
            if (FindCertificate("Root", RootCertificateName, OpenFlags.ReadOnly) == null) return false; //We must have a valid root-certificate first
            if (FindCertificate("my",CertificateName, OpenFlags.ReadOnly)!=null) return false;//Nope we alrady have this signed certificate
            string Arguments = "-pe -n \"CN=" + CertificateName + "\" -ss my -sr CurrentUser -a sha1 -sky exchange -eku 1.3.6.1.5.5.7.3.1 -in \"" + RootCertificateName + "\" -is Root -ir CurrentUser -sp \"Microsoft RSA SChannel Cryptographic Provider\" -sy 12 \"" + CertificateName + ".cer\" -m 12";
            string Result = RunDosCommand("makecert", Arguments);
            X509Certificate2 Cert = FindCertificate("my", CertificateName, OpenFlags.ReadWrite);
            if (Cert==null || !Result.ToLower().StartsWith("succeeded")) return false;
            Cert.FriendlyName = FriendlyName;
            return true;
        }
        private static X509Certificate2 FindCertificate(string Store, string Name, OpenFlags Mode)
        {//Look to see if we can find the certificate store
            X509Store store = new X509Store(Store,StoreLocation.CurrentUser);
            store.Open(Mode);
            foreach (X509Certificate2 Cert in store.Certificates)
            {
                if (Cert.Subject.ToLower() =="cn="+ Name.ToLower()) 
                    return Cert;//Yep found it
            }
            return null;
        }
    }
