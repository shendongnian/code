    // From the Article
    // Since this application only trusts a handful of LoadFrom operations,
    // we'll put them all into the same AppDomain which is a simple sandbox
    // with a full trust grant set.  The application itself will not enable
    // loadFromRemoteSources, but instead channel all of the trusted loads
    // into this domain.
    PermissionSet trustedLoadFromRemoteSourceGrantSet
        = new PermissionSet(PermissionState.Unrestricted);
     
    AppDomainSetup trustedLoadFromRemoteSourcesSetup = new AppDomainSetup();
    trustedLoadFromRemoteSourcesSetup.ApplicationBase =
        AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
     
    AppDomain trustedRemoteLoadDomain =
        AppDomain.CreateDomain("Trusted LoadFromRemoteSources Domain",
                               null,
                               trustedLoadFromRemoteSourcesSetup,
                               trustedLoadFromRemoteSourcesGrantSet);
     
    // Now all trusted remote LoadFroms can be done in the trustedRemoteLoadDomain,
    // and communicated with via a MarshalByRefObject.
