    var rawEmailBytes = GetRawEmail();  // function that gets the raw email
    var signedCmsBytes = GetSignedCmsData(rawEmailBytes)   // would pull out the signed package bytes from the email
    var signedCms = new SignedCms();
    signedCms.Decode(signedCmsBytes)
    foreach (var certificate in signedCms.Certificates) {
       StoreCertificate(certificate)   // store certificate using the cert manager.
    }
