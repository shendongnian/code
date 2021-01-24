lang-none
...
Unhandled exception. System.Exception: Failed to find or load OtherProjectName X509 certificate from local computer/personal certificate store.
 ---> System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
   at System.Collections.CollectionBase.System.Collections.IList.get_Item(Int32 index)
   at System.Security.Cryptography.X509Certificates.X509CertificateCollection.get_Item(Int32 index)
   at System.Security.Cryptography.X509Certificates.X509Certificate2Collection.get_Item(Int32 index)
...
Which was provoked by this:
lang-cs
var otherProjectNameClientCertificateColl = certificateStore
    .Certificates
    .Find(X509FindType.FindByThumbprint, _otherProjectNameCertificateStoreThumbprint, true);
var otherProjectNameClientCertificate = otherProjectNameClientCertificateColl[0];
(It was the last line that failed.)
)
