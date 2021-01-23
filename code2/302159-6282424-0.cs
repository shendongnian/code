    using System;
    using System.Security.Cryptography.X509Certificates;
    namespace Sample
    {
	class Program
	{
		static void Main(string[] args)
		{
			string base64EncodedX509 =
				"MIICBzCCAXCgAwIBAgIES6KlazANBgkqhkiG9w0BAQUFADBIMQswCQYDVQQGEwJVUzELMAkGA1UECBMCUkkxFTATBgNVBAcTDE5hcnJhZ2Fuc2V0dDEVMBMGA1UEAxMMQ29saW4gTydEZWxsMB4XDTEwMDMxODIyMTI1OVoXDTQ1MDMwOTIyMTI1OVowSDELMAkGA1UEBhMCVVMxCzAJBgNVBAgTAlJJMRUwEwYDVQQHEwxOYXJyYWdhbnNldHQxFTATBgNVBAMTDENvbGluIE8nRGVsbDCBnzANBgkqhkiG9w0BAQEFAAOBjQAwgYkCgYEAmPetcBW+ITURXY0LsI2ZfgM3R7K2kwicgpd0W+BYAXQBh76SXyN9MYvtfnUY3SNz37FW/lDQgAO3pbhEFqGwfADh2ctXlYmlE9DtcRQw0ojGVPIDlWBX+9IUxyL/89CPaN84R/1lvdosco4V0BqQYR300S9ZwmwFA2Vh9hSUZmsCAwEAATANBgkqhkiG9w0BAQUFAAOBgQBezKu4G11Z68NTPIBro8xsnbkdYxObzW7BsSr6t9MS5x6EQVs75R/nnKrsMcQ+9ImdT940jhQgZT3ZrYla5VhdbelxnLhBVbJfBdipV3Hv2bG7MnXzFqHYwQqYp+UrP8zWm1YHQf5I/P9VBjlkgwFyNKr0TxP4t/qS08oGX2wvZg==";
			var rawBytes = Convert.FromBase64String(base64EncodedX509);
			X509Certificate cert = new X509Certificate(rawBytes);
			// Parse the distinguished name to get your desired fields
			Console.WriteLine(cert.Subject); // writes CN=Colin O'Dell, L=Narragansett, S=RI, C=US
			Console.WriteLine(cert.Issuer);  // writes CN=Colin O'Dell, L=Narragansett, S=RI, C=US
		}
	}
    }
