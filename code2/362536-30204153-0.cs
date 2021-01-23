    // Add references to CERTENROLL (CertEnroll 1.0 Type Library) 
    // and CERTCLILib (CertCli 1.0 Type Library)
    using CERTCLILib;
    using CERTENROLLLib;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    using X509KeyUsageFlags = CERTENROLLLib.X509KeyUsageFlags;
    
    namespace TestSubmitEnrollment
    {
        class Program
        {
            static void Main(string[] args)
            {
                string requesterName = @"DOMAIN\otherUser";
                string caName = @"CA1.DOMAIN.LOCAL\DOMAIN-CA1-CA";
                string template = "User";
                // signerCertificate's private key must be accessible to this process
                var signerCertificate = FindCertificateByThumbprint("3f817d138f32a9a8df2aa6e43b8aed76eb93a932");
    
                // create a new private key for the certificate
                CX509PrivateKey privateKey = new CX509PrivateKey();
                // http://blogs.technet.com/b/pki/archive/2009/08/05/how-to-create-a-web-server-ssl-certificate-manually.aspx
                privateKey.ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0";
                privateKey.MachineContext = false;
                privateKey.Length = 2048;
                privateKey.KeySpec = X509KeySpec.XCN_AT_KEYEXCHANGE;
                privateKey.ExportPolicy = X509PrivateKeyExportFlags.XCN_NCRYPT_ALLOW_EXPORT_NONE;
                privateKey.Create();
    
                // PKCS 10 Request
                // we use v1 to avoid compat issues on w2k8
                IX509CertificateRequestPkcs10 req = (IX509CertificateRequestPkcs10)new CX509CertificateRequestPkcs10();
                req.InitializeFromPrivateKey(X509CertificateEnrollmentContext.ContextUser, privateKey, template);
    
                // PKCS 7 Wrapper
                var signer = new CSignerCertificate();
                signer.Initialize(false, X509PrivateKeyVerify.VerifyAllowUI, EncodingType.XCN_CRYPT_STRING_BASE64_ANY, 
                    Convert.ToBase64String(signerCertificate.GetRawCertData()));
    
                var wrapper = new CX509CertificateRequestPkcs7();
                wrapper.InitializeFromInnerRequest(req);
                wrapper.RequesterName = requesterName;
                wrapper.SignerCertificate = signer;
    
                // get CSR
                var enroll = new CX509Enrollment();
                enroll.InitializeFromRequest(wrapper);
                var csr = enroll.CreateRequest();
                //File.WriteAllText("csr.p7b", csr);
    
                // submit
                const int CR_IN_BASE64 = 1, CR_OUT_BASE64 = 1;
                const int CR_IN_PKCS7 = 0x300;
                ICertRequest2 liveCsr = new CCertRequest();
                var disposition = (RequestDisposition)liveCsr.Submit(CR_IN_BASE64 | CR_IN_PKCS7, csr, null, caName);
    
                if (disposition == RequestDisposition.CR_DISP_ISSUED)
                {
                    string resp = liveCsr.GetCertificate(CR_OUT_BASE64);
                    //File.WriteAllText("resp.cer", resp);
    
                    // install the response
                    var install = new CX509Enrollment();
                    install.Initialize(X509CertificateEnrollmentContext.ContextUser);
    
                    install.InstallResponse(InstallResponseRestrictionFlags.AllowUntrustedRoot,
                        resp, EncodingType.XCN_CRYPT_STRING_BASE64_ANY, null);
                }
                else
                {
                    Console.WriteLine("disp: " + disposition.ToString());
                }
                Console.WriteLine("done");
                Console.ReadLine();
            }
    
            private enum RequestDisposition
            {
                CR_DISP_INCOMPLETE = 0,
                CR_DISP_ERROR = 0x1,
                CR_DISP_DENIED = 0x2,
                CR_DISP_ISSUED = 0x3,
                CR_DISP_ISSUED_OUT_OF_BAND = 0x4,
                CR_DISP_UNDER_SUBMISSION = 0x5,
                CR_DISP_REVOKED = 0x6,
                CCP_DISP_INVALID_SERIALNBR = 0x7,
                CCP_DISP_CONFIG = 0x8,
                CCP_DISP_DB_FAILED = 0x9
            }
    
            private static X509Certificate2 FindCertificateByThumbprint(string sslCertThumbprint)
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                try
                {
                    store.Open(OpenFlags.ReadOnly);
    
                    var certs = store.Certificates.Find(X509FindType.FindByThumbprint, sslCertThumbprint, true);
                    if (certs.Count > 0)
                    {
                        return certs[0];
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
                finally
                {
                    store.Close();
                }
            }
    
            // we re-declare this to account for backcompat to 2k8
            [ComImport, Guid("884E2042-217D-11DA-B2A4-000E7BBB2B09")]
            class CX509CertificateRequestPkcs10
            {
            }
        }
    }
