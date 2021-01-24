 			//Guid guidContainerName = Guid.NewGuid();
            Guid guidContainerName = Guid.Empty;
            int nRet = UuidCreate(out guidContainerName);
            if (nRet == 0)
            {
                IntPtr pContainerName = new IntPtr();
                nRet = UuidToString(ref guidContainerName, ref pContainerName);
                string sContainerName;
                sContainerName = Marshal.PtrToStringUni(pContainerName);
                string sProviderName = MS_DEF_PROV;
                IntPtr hProv = IntPtr.Zero;
                bool bRet = CryptAcquireContext(ref hProv, sContainerName, MS_DEF_PROV, PROV_RSA_FULL, CRYPT_NEWKEYSET);
                IntPtr hKey = IntPtr.Zero;
                bRet = CryptGenKey(hProv, AT_KEYEXCHANGE, RSA1024BIT_KEY | CRYPT_EXPORTABLE, ref hKey);               
                string sSubject = "CN=TEST,OU=TESTOU";               
                byte[] encodedSubjectName = null;
                uint nNameLenght = 0;
                if (CertStrToName(X509_ASN_ENCODING, sSubject, CERT_X500_NAME_STR, IntPtr.Zero, null, ref nNameLenght, IntPtr.Zero))
                {
                    encodedSubjectName = new byte[nNameLenght];
                    CertStrToName(X509_ASN_ENCODING, sSubject, CERT_X500_NAME_STR, IntPtr.Zero, encodedSubjectName, ref nNameLenght, IntPtr.Zero);
                }              
                CERT_NAME_BLOB subjectblob = new CERT_NAME_BLOB();
                subjectblob.pbData = Marshal.AllocHGlobal(encodedSubjectName.Length);
                Marshal.Copy(encodedSubjectName, 0, subjectblob.pbData, encodedSubjectName.Length);
                subjectblob.cbData = encodedSubjectName.Length;
                CRYPT_KEY_PROV_INFO pKeyProvInfo = new CRYPT_KEY_PROV_INFO();
                pKeyProvInfo.pwszContainerName = sContainerName;
                pKeyProvInfo.pwszProvName = sProviderName;
                pKeyProvInfo.dwProvType = PROV_RSA_FULL;
                pKeyProvInfo.rgProvParam = IntPtr.Zero;
                pKeyProvInfo.dwKeySpec = AT_KEYEXCHANGE;
                
                IntPtr pcCertContext = CertCreateSelfSignCertificate(hProv, ref subjectblob, 0, ref pKeyProvInfo, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
                if (pcCertContext != IntPtr.Zero)
                {
                    X509Certificate cert = new X509Certificate(pcCertContext);
                    // Add reference to System.Security
                    X509Certificate2UI.DisplayCertificate(new X509Certificate2(cert));
                    CertFreeCertificateContext(pcCertContext);
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }                            
                Marshal.FreeHGlobal(subjectblob.pbData);               
                CryptDestroyKey(hKey);
                CryptReleaseContext(hProv, 0);
                RpcStringFree(ref pContainerName);
            }
          
