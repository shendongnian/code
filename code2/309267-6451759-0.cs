	System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(StoreName.My, StoreLocation.CurrentUser);
	store.Open(); // Dont forget. otherwise u will get an exception.
	X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindBySubjectName,"XYZ",true);
	if(certs.Count > 0)
	{
		// Certificate is found.
	}
	else
	{
		// No Certificate found by that subject name.
	}
