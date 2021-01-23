    using Standard.Licensing.Validation;
    
    var license = License.Load(...);
    var validationFailures = license.Validate()  
                                    .ExpirationDate()  
                                    .When(lic => lic.Type == LicenseType.Trial)  
                                    .And()  
                                    .Signature(publicKey)  
                                    .AssertValidLicense();
