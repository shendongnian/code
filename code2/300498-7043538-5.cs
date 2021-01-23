    var myCertIdId = identities.Find(x => x.AuthenticationType == "X509");
    
                var myCertThumbprint = myCertIdId != null
                                         ? myCertIdId.Name.Substring(myCertIdId.Name.LastIndexOf(';') + 2)
                                         : "";
    
                var store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine);
    
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
    
                var certCol =
                    store.Certificates.Find(X509FindType.FindByThumbprint, myCertThumbprint, false);
    
                store.Close();
    var myCert = certCol[0];
