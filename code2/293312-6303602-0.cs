    svh.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = System.ServiceModel.Security.UserNamePasswordValidationMode.Custom;
    People365UserNameValidator cs = new People365UserNameValidator();
    svh.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = cs;
    svh.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine,
    StoreName.TrustedPeople, X509FindType.FindByIssuerName, "Certificate Name");
