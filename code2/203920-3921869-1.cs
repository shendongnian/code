    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Security.Cryptography;
    using Pkcs = System.Security.Cryptography.Pkcs;
    using X509 = System.Security.Cryptography.X509Certificates;
    
    public class FormEncryption
    {
        private Encoding _encoding = Encoding.Default;
        private string _recipientPublicCertPath;
    
        private X509.X509Certificate2 _signerCert;
        private X509.X509Certificate2 _recipientCert;
    
        /// <summary>
        /// Character encoding, e.g. UTF-8, Windows-1252
        /// </summary>
        public string Charset
        {
            get { return _encoding.WebName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _encoding = Encoding.GetEncoding(value);
                }
            }
        }
    
        /// <summary>
        /// Path to the recipient's public certificate in PEM format
        /// </summary>
        public string RecipientPublicCertPath
        {
            get { return _recipientPublicCertPath; }
            set
            {
                _recipientPublicCertPath = value;
                _recipientCert = new X509.X509Certificate2(_recipientPublicCertPath);
            }
        }
    
        /// <summary>
        ///  Loads the PKCS12 file which contains the public certificate
        /// and private key of the signer
        /// </summary>
        /// <param name="signerPfxCertPath">
        /// File path to the signer's public certificate plus private key
        /// in PKCS#12 format</param>
        /// <param name="signerPfxCertPassword">
        /// Password for signer's private key</param>
        public void LoadSignerCredential(string signerPfxCertPath, string signerPfxCertPassword)
        {
            _signerCert = new X509.X509Certificate2(signerPfxCertPath, signerPfxCertPassword);
        }
    
        /// <summary>
        /// Sign a message and encrypt it for the recipient.
        /// </summary>
        /// <param name="clearText">Name value pairs
        /// must be separated by \n (vbLf or chr&#40;10)),
        /// for example "cmd=_xclick\nbusiness=..."</param>
        /// <returns></returns>
        public string SignAndEncrypt(string clearText)
        {
            string result = null;
    
            byte[] messageBytes = _encoding.GetBytes(clearText);
            byte[] signedBytes = Sign(messageBytes);
            byte[] encryptedBytes = Envelope(signedBytes);
    
            result = Base64Encode(encryptedBytes);
    
            return result;
        }
    
        private byte[] Sign(byte[] messageBytes)
        {
            Pkcs.ContentInfo content = new Pkcs.ContentInfo(messageBytes);
            Pkcs.SignedCms signed = new Pkcs.SignedCms(content);
            Pkcs.CmsSigner signer = new Pkcs.CmsSigner(_signerCert);
            signed.ComputeSignature(signer);
            byte[] signedBytes = signed.Encode();
    
            return signedBytes;
        }
    
        private byte[] Envelope(byte[] contentBytes)
        {
            Pkcs.ContentInfo content = new Pkcs.ContentInfo(contentBytes);
            Pkcs.EnvelopedCms envMsg = new Pkcs.EnvelopedCms(content);
            Pkcs.CmsRecipient recipient = new Pkcs.CmsRecipient(Pkcs.SubjectIdentifierType.IssuerAndSerialNumber, _recipientCert);
            envMsg.Encrypt(recipient);
            byte[] encryptedBytes = envMsg.Encode();
    
            return encryptedBytes;
        }
    
        private string Base64Encode(byte[] encoded)
        {
            const string PKCS7_HEADER = "-----BEGIN PKCS7-----";
            const string PKCS7_FOOTER = "-----END PKCS7-----";
    
            string base64 = Convert.ToBase64String(encoded);
            StringBuilder formatted = new StringBuilder();
            formatted.Append(PKCS7_HEADER);
            formatted.Append(base64);
            formatted.Append(PKCS7_FOOTER);
    
            return formatted.ToString();
        }
    }
