    public ActionResult RegistrationTracking(EncryptedId sourceId)
    {
        var registration = learnerRegistrationService.Get(sourceId);
        return ViewWithSanction (registration.Qualification, View());
    }
    
    public ActionResult Index(EncryptedId achievableVersionId)
    {
        var achievableVersion = achievableVersionService.Get(achievableVersionId);
        return ViewWithSanction (achievableVersion, View());
    }
